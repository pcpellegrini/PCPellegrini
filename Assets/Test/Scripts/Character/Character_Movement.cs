using UnityEngine;
using System.Collections;

public class Character_Movement : MonoBehaviour {

    public float maxSpeed;
    public float acceleration;
    public float impulseForce;

    [HideInInspector] public float currentSpeed = 0f;
    [HideInInspector] public float speedMultiplier = 1f;
    [HideInInspector] public float direction;
    [HideInInspector] public Character character;
    [HideInInspector] public Rigidbody mainRB;

    public void Initialize()
    {

    }

    public void Jump()
    {
        mainRB.AddForce(Vector3.up * impulseForce, ForceMode.Impulse);
    }

    void FixedUpdate()
    {
        if(character.isMoving && currentSpeed < maxSpeed)
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
        if(mainRB.velocity.x != __newSpeed)
            mainRB.velocity = new Vector3(__newSpeed, mainRB.velocity.y, 0f);
    }
}
