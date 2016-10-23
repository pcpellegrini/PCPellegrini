using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
    
    public Character_Input charInput;
    public Character_Movement charMovement;
    public Character_WindControl charWind;
    public Character_Rope charRope;
    public Rigidbody charRB;
    public Transform handPosition;
    public Camera mainCam;
    public GameObject camGO;
    public Global_Vars.CONDITIONS condition;

    [HideInInspector] public bool isMoving;
    [HideInInspector] public bool isGrounded;
    [HideInInspector] public bool isClimbing;
    [HideInInspector] public bool toClimb;
    [HideInInspector] public bool postClimb;
    [HideInInspector] public bool facingRight;
    [HideInInspector] public bool isHolding = false;
    [HideInInspector] public bool isClimbingRope = false;

    void Start()
    {
        Initialize();
    }
	
    void Initialize()
    {
        Global_Vars.player = this;
        facingRight = true;
        if(mainCam != null)
        {
            Camera_Move __camCS = mainCam.gameObject.transform.root.GetComponent<Camera_Move>();
            __camCS.character = this;
            __camCS.enabled = true;
            __camCS.Initialize();
        }
        charMovement.mainRB = charRB;
        charMovement.character = this;
        charInput.character = this;
        charInput.enabled = true;
        charMovement.enabled = true;
        charRope.character = this;
        charRope.enabled = true;
    }
}
