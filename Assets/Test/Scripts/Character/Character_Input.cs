using UnityEngine;
using System.Collections;

public class Character_Input : MonoBehaviour
{
    [HideInInspector]
    public Character character;

	void Update () {
        if(Input.GetButtonDown("Jump") && character.isGrounded)
        {
            character.charMovement.Jump();
        }
        float __dir = Input.GetAxisRaw("Horizontal"); ;
        if (__dir != 0)
        {
            character.isMoving = true;
            character.charMovement.direction = __dir;
        }
        else if (character.isMoving)
        {
            character.isMoving = false;
        }
    }
}
