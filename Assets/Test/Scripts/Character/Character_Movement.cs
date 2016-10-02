using UnityEngine;
using System.Collections;

public class Character_Movement : MonoBehaviour {

    public float maxSpeed = 10f;
    public float acceleration = 0.5f;
    public float impulseForce = 600f;
    public float climbVelocity = 100f;
    public float groundCheckDistance = 0.1f;
    public float scalableCheckDistance = 0.5f;
    [HideInInspector] public float currentSpeed = 0f;
    [HideInInspector] public float speedMultiplier = 1f;
    [HideInInspector] public float direction;
    [HideInInspector] public Character character;
    [HideInInspector] public Rigidbody mainRB;

    private float _lastYVelocity = 0f;
    private float _lastYPosition = 0f;
    private float _offsetY = 0.05f;

    public void Initialize()
    {
    }

    public void Jump()
    {
        CheckScalable();
        mainRB.AddForce(Vector3.up * impulseForce, ForceMode.Impulse);
        character.isGrounded = false;
    }

    void FixedUpdate()
    {
        if (character.isMoving && currentSpeed < maxSpeed)
        {
            currentSpeed += acceleration;
        }
        else if(!character.isMoving && currentSpeed > 0)
        {
            if(currentSpeed - acceleration < 0)
            {
                currentSpeed = 0f;
            }
            else
            {
                currentSpeed -= acceleration;
            }
        }

        float __newSpeed = direction * currentSpeed * speedMultiplier;
        if (!character.isClimbing && !character.postClimb)
        {
            if (mainRB.velocity.x != __newSpeed)
                mainRB.velocity = new Vector3(__newSpeed, mainRB.velocity.y, 0f);
        }
    }

    void Update()
    {
        if(mainRB.velocity.y != _lastYVelocity)
        {
            CheckGroundStatus();
            _lastYVelocity = mainRB.velocity.y;
        }

        if(character.facingRight && direction < 0 )
        {
            character.facingRight = false;
            iTween.RotateTo(gameObject, iTween.Hash("y", -90,"time", 0.5,"easetype", "easeInOutSine"));
        }
        else if(!character.facingRight && direction > 0)
        {
            character.facingRight = true;
            iTween.RotateTo(gameObject, iTween.Hash("y", 90, "time", 0.5, "easetype", "easeInOutSine"));
        }
        if (transform.position.y < _lastYPosition)
        {
            if (character.toClimb && !character.isClimbing)
            {
                character.isClimbing = true;
                character.toClimb = false;
                mainRB.useGravity = false;
            }
            else if (character.postClimb)
            {
                character.postClimb = false;
            }
        }

        _lastYPosition = transform.position.y;
        if (character.isClimbing)
        {
            mainRB.velocity = new Vector3(0f, climbVelocity, 0f);
            CheckScalable();
        }
    }

    public void CheckGroundStatus()
    {
        RaycastHit hitInfo;
#if UNITY_EDITOR
        Debug.DrawLine(transform.position + (Vector3.up * _offsetY), transform.position + (Vector3.up * _offsetY) + (Vector3.down * groundCheckDistance));
#endif
        if (Physics.Raycast(transform.position + (Vector3.up * _offsetY), Vector3.down, out hitInfo, groundCheckDistance))
        {
            character.isGrounded = true;
        }
        else
        {
            character.isGrounded = false;
        }
    }

    public void CheckScalable()
    {
        RaycastHit hitInfo;
#if UNITY_EDITOR
        Debug.DrawLine(transform.position, transform.position + (transform.forward * scalableCheckDistance));
#endif
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, scalableCheckDistance))
        {
            if (hitInfo.collider.gameObject.tag == "Scalable" && !character.isClimbing)
            {
                character.toClimb = true;
            }
        }
        else if(character.isClimbing)
        {
            mainRB.AddForce(transform.forward * impulseForce/3, ForceMode.Impulse);
            character.postClimb = true;
            mainRB.useGravity = true;
            character.isClimbing = false;
            character.toClimb = false;
        }
    }
}
