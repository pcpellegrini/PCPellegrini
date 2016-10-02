using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character_WindControl : MonoBehaviour {

    public float windDistance;
    public float windRadius;
    public float windForce;
    [HideInInspector]
    public bool windEnabled;
    [HideInInspector]
    public List<GameObject> activeObjects = new List<GameObject>();

    private Vector3 _currentDirection;

    void Update()
    {
        if(windEnabled)
        {
            for (int i = 0; i < activeObjects.Count; i++)
            {
                int __num = i;
                activeObjects[__num].GetComponent<Rigidbody>().AddForce(_currentDirection * windForce);
            }
        }
        else if(activeObjects.Count != 0)
        {
            activeObjects.Clear();
        }
    }

	public void EnableWind(int p_dirH, int p_dirV)
    {
        windEnabled = true;
        RaycastHit hitInfo;
        _currentDirection = new Vector3(p_dirH, p_dirV, 0);
        Vector3 __dir = new Vector3(_currentDirection.x, _currentDirection.y, 0);
        Vector3 __pos = transform.position;
#if UNITY_EDITOR
        Debug.DrawLine(__pos, __pos + (__dir * windDistance), Color.red);
        Debug.DrawLine(__pos, __pos - (__dir * windDistance), Color.red);
#endif

        if (Physics.SphereCast(__pos, windRadius, __dir, out hitInfo, windDistance))
        {
            if (hitInfo.collider.gameObject.tag == "DynamicObject")
            {
                activeObjects.Add(hitInfo.collider.gameObject);
            }
        }
        if (Physics.SphereCast(__pos, windRadius, -__dir, out hitInfo, windDistance))
        {
            if (hitInfo.collider.gameObject.tag == "DynamicObject")
            {
                activeObjects.Add(hitInfo.collider.gameObject);
            }
        }
    }
}
