using UnityEngine;
using System.Collections;

public class Character_Rope : MonoBehaviour {

    [HideInInspector]
    public Character character;
    public GameObject ropeBone;
    public float climbDist = 0;
    

    // Update is called once per frame
    void Update()
    {

        if (character.isHolding && ropeBone)
        {
            int __dir = 1;
            if (!character.facingRight)
                __dir = -1;
            transform.position = new Vector3(ropeBone.transform.position.x - (character.handPosition.localPosition.z * __dir), (ropeBone.transform.position.y + climbDist) - character.handPosition.localPosition.y, transform.position.z);
            character.charRB.velocity = new Vector2(ropeBone.gameObject.GetComponent<Rigidbody>().velocity.x, 0);
            ropeBone.gameObject.GetComponent<Rigidbody>().velocity += new Vector3(Input.GetAxis("Horizontal") / 5, 0, 0);
            if (Input.GetAxis("Vertical") != 0)
            {
                character.isClimbingRope = true;
                climbDist += Input.GetAxis("Vertical") / 10;
            }
            else
            {
                character.isClimbingRope = false;
                climbDist = 0f;
            }
        }

        if (Input.GetButtonUp("Jump") && ropeBone)
        {
            character.isHolding = false;
            climbDist = 0f;
            character.charRB.AddRelativeForce(ropeBone.gameObject.GetComponent<Rigidbody>().velocity * 100);
            ropeBone = null;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Rope" && !ropeBone && Input.GetButton("Jump"))
        {
            ropeBone = other.gameObject;
            character.isHolding = true;
            Vector3 playerVelx = new Vector2(character.charRB.velocity.x, 0);
            ropeBone.gameObject.GetComponent<Rigidbody>().velocity = playerVelx * 10;
        }

        if (other.tag == "Rope" && ropeBone && character.isClimbingRope)
        {
            ropeBone = other.gameObject;
            climbDist = (transform.position.y + character.handPosition.localPosition.y) - ropeBone.transform.position.y;
        }
    }

    /*void OnTriggerExit(Collider other)
    {
        if (other.tag == "Rope" && character.isHolding)
        {
            character.isHolding = false;
            character.isClimbingRope = false;
        }
    }*/
}
