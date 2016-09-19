using UnityEngine;
using System.Collections;

public class Camera_Spot : MonoBehaviour {
    
    public bool changeCharVelocity;
    public float newVelocity;
    public bool changeCharCondition;
    public Character.CONDITIONS newCondition;

    public void Initialize()
    {

    }

    public void SpotAction(Character p_char)
    {
        if(changeCharVelocity)
        {
            p_char.charMovement.speedMultiplier = newVelocity;
        }
        if(changeCharCondition)
        {
            p_char.condition = newCondition;
        }
    }

}
