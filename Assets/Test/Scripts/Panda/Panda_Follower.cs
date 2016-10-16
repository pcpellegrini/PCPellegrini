using UnityEngine;
using System.Collections;

public class Panda_Follower : MonoBehaviour {

    public Transform eyesPosition;
    public float visionRadius;
    public float visionDistance;

    [HideInInspector]
    public Panda panda;
    [HideInInspector]
    public bool charIsClose;

    void Start()
    {
        Invoke("CheckChar", 1f);
    }

    public void CheckChar()
    {
        RaycastHit __hitInfo;
        if (Physics.SphereCast(eyesPosition.position, visionRadius, transform.forward, out __hitInfo, visionDistance))
        {
            if (__hitInfo.collider.gameObject.tag == "Player")
            {
                charIsClose = true;
            }
            else
            {
                charIsClose = false;
            }
        }
        Invoke("CheckChar", 2f);
    }
}
