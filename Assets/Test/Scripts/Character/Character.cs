using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

    public Character_Input charInput;
    public Character_Movement charMovement;
    public Rigidbody charRB;
    public Camera mainCam;

    [HideInInspector]
    public bool isMoving;


    void Start()
    {
        Initialize();
    }
	
    void Initialize()
    {
        Debug.Log(mainCam.gameObject.name);
        /*Camera_Move __camCS = mainCam.gameObject.GetComponent<Camera_Move>();
        __camCS.character = this;
        __camCS.enabled = true;*/
        charMovement.mainRB = charRB;
        charMovement.character = this;
        charInput.character = this;
        charInput.enabled = true;
        charMovement.enabled = true;
        
    }
}
