using UnityEngine;
using System.Collections;

public class Panda : MonoBehaviour {

    
    public Panda_Input pandaInput;
    public Panda_Movement pandaMovement;
    public Panda_Follower pandaFollower;
    public Rigidbody pandaRB;
    public Camera mainCam;
    public GameObject camGO;
    public Global_Vars.CONDITIONS condition;
    public NavMeshAgent pandaNavAgent;
    public LayerMask playerMask;

    [HideInInspector]
    public bool isMoving;
    [HideInInspector]
    public bool isGrounded;
    [HideInInspector]
    public bool facingRight;
    [HideInInspector]
    public Global_Vars.PANDA_STATE currentState;

    void Start()
    {
        Initialize();
        currentState = Global_Vars.PANDA_STATE.FOLLOW;
    }

    void Initialize()
    {
        facingRight = true;
        pandaMovement.mainRB = pandaRB;
        pandaMovement.panda = this;
        pandaFollower.panda = this;
        pandaFollower.enabled = true;
        pandaInput.panda = this;
        //pandaInput.enabled = true;
        pandaMovement.enabled = true;
    }
}
