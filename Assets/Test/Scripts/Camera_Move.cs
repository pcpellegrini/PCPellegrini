using UnityEngine;
using System.Collections;

public class Camera_Move : MonoBehaviour {

    public Transform[] paths;

    [HideInInspector] public Character character;

    private int _currentPath = 0;
    private int _nextPath;
    private float _currentPathPercent = 0.0f; // min 0, max 1

    public void Initialize()
    {

    }

    void Update()
    {
        float __off = paths[paths.Length - 1].position.x - paths[0].position.x;
        _currentPathPercent = ((character.transform.position.x - paths[0].position.x) / __off);
        iTween.PutOnPath(gameObject, paths, _currentPathPercent);
    }

    void OnDrawGizmos()
    {
        iTween.DrawPath(paths);
    }
}
