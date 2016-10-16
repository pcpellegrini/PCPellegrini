using UnityEngine;
using System.Collections;

public class Panda_Input : MonoBehaviour {

    [HideInInspector]
    public Panda panda;

    void Update()
    {
        if (Input.GetButtonDown("Jump") && panda.isGrounded)
        {
            panda.pandaMovement.Jump();
        }
        float __dir = Input.GetAxisRaw("Horizontal"); ;
        if (__dir != 0)
        {
            panda.isMoving = true;
            panda.pandaMovement.direction = __dir;
        }
        else if (panda.isMoving)
        {
            panda.isMoving = false;
        }
    }
}
