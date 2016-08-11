using UnityEngine;
using System.Collections;
using System;

public class p_standarts : MonoBehaviour {
    
    // enum vars all in upper case
    public enum VARENUM
    {
        TYPE1,
        TYPE2,
        TYPE3
    }
    // Public Vars (Public var always start with lower case and uppercase in word separation)
    public VARENUM varType;
    public event Action<string> varEvent;
    public bool varBool;
    public int varint;
    public float varfloat;
    public Collider varCollider;

    // Private Vars (Private var start with a underline before the name)
    private bool _varBoolPriv;
    private int _varIntPriv;
    private float _varFloatPriv;
    private Collider _varColliderPriv;

    // Unity methods
    void Start()
    {
        // Local vars always start with a double underline
        float __varfloatLocal = 0f;
        __varfloatLocal++;
    }
    void OnCollisionEnter(Collision p_collision)
    {
        
    }

    // Public Methods
    public void MethodName(bool p_value)
    {
        //Methods always start with uppercase in all words;
        //Parameters always has a "p_" as prefix;
    }

    // Private Methods
    private void _PrivMethodName(int p_value)
    {
        // Private methods start with a underline before name
    }
}
