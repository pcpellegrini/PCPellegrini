using UnityEngine;
using System.Collections;

public class Character_Input : MonoBehaviour
{
    [HideInInspector]
    public Character character;

	void Update () {
        if(Input.GetButtonDown("Jump"))
        {
            character.charMovement.Jump();
        }
        if (Input.GetButtonDown("Horizontal"))
        {
            character.isMoving = true;
            character.charMovement.direction = Input.GetAxisRaw("Horizontal");
        }
        if (Input.GetButtonUp("Horizontal") && Input.GetAxisRaw("Horizontal") == 0)
        {
            character.isMoving = false;
        }
    }
}
