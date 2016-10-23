using UnityEngine;
using System.Collections;

public class Panda_Follower : MonoBehaviour {

    public Transform eyesPosition;
    public float visionRadius;
    public float visionDistance;
    public float closeRadius;
    public float closeDistance;

    [HideInInspector]
    public Panda panda;
    [HideInInspector]
    public bool charIsClose;

    private Vector3 _playerOffset = new Vector3(2f, 0f, 0f);

    void Start()
    {
        Invoke("CheckChar", 1f);
    }

    public void CheckChar()
    {
        RaycastHit __hitInfo;
#if UNITY_EDITOR
        Debug.DrawLine(eyesPosition.position, eyesPosition.position + (panda.gameObject.transform.forward * closeDistance));
#endif
        if (Physics.SphereCast(eyesPosition.position, closeRadius, transform.forward, out __hitInfo, closeDistance, panda.playerMask))
        {
            Debug.Log("close");
            charIsClose = true;
            panda.pandaNavAgent.Stop();
        }
        else
        {
            Debug.Log("far");
            charIsClose = false;
            SeekPlayer();
        }
        Invoke("CheckChar", 1f);
    }

    public void SeekPlayer()
    {
        panda.pandaNavAgent.Resume();
        Vector3 __playerPos = Global_Vars.player.gameObject.transform.position;
        if ((panda.facingRight && (__playerPos.x < transform.position.x)) || (!panda.facingRight && (__playerPos.x > transform.position.x)))
            panda.pandaMovement.Turn();
        if(__playerPos.x < transform.position.x)
            panda.pandaNavAgent.SetDestination(__playerPos + _playerOffset);
        else if (__playerPos.x > transform.position.x)
            panda.pandaNavAgent.SetDestination(__playerPos - _playerOffset);
        //CancelInvoke("CheckChar");
        //Invoke("CheckChar", 0.5f);
    }
}
