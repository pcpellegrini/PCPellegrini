using UnityEngine;
using System.Collections;

public class Camera_Spot : MonoBehaviour {
    
    public bool changeCharVelocity;
    public float newVelocity;
    public bool changeCharCondition;
    public Global_Vars.CONDITIONS newCondition;

    public void Initialize()
    {

    }

    public void SpotAction(Character p_char, Camera_Move p_cam)
    {
        if(changeCharVelocity)
        {
            p_char.charMovement.speedMultiplier = newVelocity;
        }
        if(changeCharCondition)
        {
            p_char.condition = newCondition;
            switch(newCondition)
            {
                case Global_Vars.CONDITIONS.SCARED:
                    p_cam.Animate(Camera_Move.CAM_AIMATIONS.SHAKE);
                    break;
                case Global_Vars.CONDITIONS.NORMAL:
                    p_cam.Animate(Camera_Move.CAM_AIMATIONS.IDLE);
                    break;
            }
        }
    }

}
