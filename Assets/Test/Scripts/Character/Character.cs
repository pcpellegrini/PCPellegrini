using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

    public enum CONDITIONS
    {
        HURT,
        COLD,
        SCARED,
        TIRED,
        NORMAL
    }
    public Character_Input charInput;
    public Character_Movement charMovement;
    public Character_WindControl charWind;
    public Rigidbody charRB;
    public Camera mainCam;
    public GameObject camGO;
    public CONDITIONS condition;

    [HideInInspector] public bool isMoving;
    [HideInInspector] public bool isGrounded;
    [HideInInspector] public bool isClimbing;
    [HideInInspector] public bool toClimb;
    [HideInInspector] public bool postClimb;
    [HideInInspector] public bool facingRight;

    void Start()
    {
        Initialize();
    }
	
    void Initialize()
    {
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
    }
}
