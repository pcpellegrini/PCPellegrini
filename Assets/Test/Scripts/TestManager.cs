using UnityEngine;
using System.Collections;

public class TestManager : MonoBehaviour {

    public Transform leftFront;
    public Transform rightFront;
    public Transform leftBack;
    public Transform rightBack;

    // Use this for initialization
    void Start () {
	    for(int i = 0; i < 500; i++)
        {
            CreateObj();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void CreateObj()
    {
        GameObject __obj;
        int __rnd = Random.Range(0, 2);
        switch(__rnd)
        {
            case 0:
                __obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                break;
            case 1:
                __obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                break;
            default:
                __obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                break;
        }
        Renderer __rend = __obj.GetComponent<Renderer>();
        __rend.material.color = RandColor();
        __obj.transform.localScale *= Random.Range(0.5f, 5f);
        __obj.AddComponent<Rigidbody>();
        __obj.transform.position = new Vector3(Random.Range(leftBack.transform.position.x, rightBack.transform.position.x), leftFront.transform.position.y, Random.Range(leftBack.transform.position.z, leftFront.transform.position.z));
    }

    private Color RandColor()
    {
        Color __color = new Color(Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        return __color;
    }
}
