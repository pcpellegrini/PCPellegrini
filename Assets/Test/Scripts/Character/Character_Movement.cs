using UnityEngine;
using System.Collections;

public class Character_Movement : MonoBehaviour {

    public float maxSpeed = 10f;
    public float acceleration = 0.5f;
    public float impulseForce = 600f;
    public float groundCheckDistance = 0.1f;
    [HideInInspector] public float currentSpeed = 0f;
    [HideInInspector] public float speedMultiplier = 1f;
    [HideInInspector] public float direction;
    [HideInInspector] public Character character;
    [HideInInspector] public Rigidbody mainRB;

    private float _lastYVelocity = 0f;
    private float _offsetY = 0.05f;

    public void Initialize()
    {

    }

    public void Jump()
    {
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
        if (mainRB.velocity.x != __newSpeed)
            mainRB.velocity = new Vector3(__newSpeed, mainRB.velocity.y, 0f);
    }

    void Update()
    {
        if(mainRB.velocity.y != _lastYVelocity)
        {
            CheckGroundStatus();
            _lastYVelocity = mainRB.velocity.y;
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
}
