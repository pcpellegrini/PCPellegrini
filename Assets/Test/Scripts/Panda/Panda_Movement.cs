using UnityEngine;
using System.Collections;

public class Panda_Movement : MonoBehaviour {

    public float maxSpeed = 10f;
    public float acceleration = 0.5f;
    public float impulseForce = 600f;
    public float climbVelocity = 100f;
    public float groundCheckDistance = 0.1f;
    public float scalableCheckDistance = 0.5f;
    [HideInInspector]
    public float currentSpeed = 0f;
    [HideInInspector]
    public float speedMultiplier = 1f;
    [HideInInspector]
    public float direction;
    [HideInInspector]
    public Panda panda;
    [HideInInspector]
    public Rigidbody mainRB;

    private float _lastYVelocity = 0f;
    private float _lastYPosition = 0f;
    private float _offsetY = 0.05f;

    public void Initialize()
    {

    }

    public void Jump()
    {
        //CheckScalable();
        mainRB.AddForce(Vector3.up * impulseForce, ForceMode.Impulse);
        panda.isGrounded = false;
    }

    void FixedUpdate()
    {
        if (panda.isMoving && currentSpeed < maxSpeed)
        {
            currentSpeed += acceleration;
        }
        else if (!panda.isMoving && currentSpeed > 0)
        {
            if (currentSpeed - acceleration < 0)
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
        if (mainRB.velocity.y != _lastYVelocity)
        {
            CheckGroundStatus();
            _lastYVelocity = mainRB.velocity.y;
        }

        if (panda.facingRight && direction < 0)
        {
            panda.facingRight = false;
            iTween.RotateTo(gameObject, iTween.Hash("y", 0, "time", 0.5, "easetype", "easeInOutSine"));
        }
        else if (!panda.facingRight && direction > 0)
        {
            panda.facingRight = true;
            iTween.RotateTo(gameObject, iTween.Hash("y", 180, "time", 0.5, "easetype", "easeInOutSine"));
        }
        /*if (transform.position.y < _lastYPosition)
        {
            if (panda.toClimb && !panda.isClimbing)
            {
                panda.isClimbing = true;
                panda.toClimb = false;
                mainRB.useGravity = false;
            }
            else if (panda.postClimb)
            {
                panda.postClimb = false;
            }
        }*/

        _lastYPosition = transform.position.y;
        /*if (panda.isClimbing && !panda.isHolding)
        {
            mainRB.velocity = new Vector3(0f, climbVelocity, 0f);
            CheckScalable();
        }*/
    }

    public void CheckGroundStatus()
    {
        RaycastHit hitInfo;
#if UNITY_EDITOR
        Debug.DrawLine(transform.position + (Vector3.up * _offsetY), transform.position + (Vector3.up * _offsetY) + (Vector3.down * groundCheckDistance));
#endif
        if (Physics.Raycast(transform.position + (Vector3.up * _offsetY), Vector3.down, out hitInfo, groundCheckDistance))
        {
            panda.isGrounded = true;
        }
        else
        {
            panda.isGrounded = false;
        }
    }

    /*public void CheckScalable()
    {
        RaycastHit hitInfo;
#if UNITY_EDITOR
        Debug.DrawLine(transform.position, transform.position + (transform.forward * scalableCheckDistance));
#endif
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, scalableCheckDistance))
        {
            if (hitInfo.collider.gameObject.tag == "Scalable" && !panda.isClimbing)
            {
                panda.toClimb = true;
            }
        }
        else if (panda.isClimbing)
        {
            mainRB.AddForce(transform.forward * impulseForce / 3, ForceMode.Impulse);
            panda.postClimb = true;
            mainRB.useGravity = true;
            panda.isClimbing = false;
            panda.toClimb = false;
        }
    }*/
}
