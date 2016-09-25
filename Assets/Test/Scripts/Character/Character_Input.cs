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

        int __dirWindH = (int)Input.GetAxisRaw("Wind_H");
        int __dirWindV = (int)Input.GetAxisRaw("Wind_V");
        if(__dirWindH != 0 || __dirWindV != 0)
        {
            character.charWind.EnableWind(__dirWindH, __dirWindV);
        }
        else if(character.charWind.windEnabled)
        {
            character.charWind.windEnabled = false;
        }
    }
}
