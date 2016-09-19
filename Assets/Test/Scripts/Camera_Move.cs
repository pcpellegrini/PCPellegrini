using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Camera_Move : MonoBehaviour {

    public Transform[] paths;
    public Transform[] targetPaths;
    public GameObject camTarget;

    [HideInInspector] public Character character;

    private int _currentPath;
    private int _currentTargetPath;
    private int _nextPath;
    private int _nextTargetPath;
    private float _currentPathPercent = 0.0f; // min 0, max 1
    private float _currentTargetPathPercent = 0.0f; // min 0, max 1
    private List<Camera_Spot> spots = new List<Camera_Spot>();

    public void Initialize()
    {
        _nextPath = _currentPath++;
        _nextTargetPath = _currentTargetPath++;
        foreach(Transform tmp in paths)
        {
            spots.Add(tmp.gameObject.GetComponent<Camera_Spot>());
        }
    }

    void Update()
    {
        float __off = paths[paths.Length - 1].position.x - paths[0].position.x;
        float __offT = targetPaths[targetPaths.Length - 1].position.x - targetPaths[0].position.x;
        _currentPathPercent = ((character.transform.position.x - paths[0].position.x) / __off);
        _currentTargetPathPercent = ((character.transform.position.x - targetPaths[0].position.x) / __offT);
        iTween.PutOnPath(gameObject, paths, _currentPathPercent);
        iTween.PutOnPath(camTarget, targetPaths, _currentTargetPathPercent);
        if(transform.position.x >= paths[_nextPath].position.x)
        {
            _currentPath = _nextPath;
            spots[_currentPath].SpotAction(character);
            if (_nextPath < paths.Length-1)
            {
                _nextPath++;
            }
        }
        if (camTarget.transform.position.x >= targetPaths[_nextTargetPath].position.x)
        {
            _currentTargetPath = _nextTargetPath;
            if (_nextTargetPath < targetPaths.Length - 1)
            {
                _nextTargetPath++;
            }
        }
        transform.LookAt(camTarget.transform);
    }

    void OnDrawGizmos()
    {
        iTween.DrawPath(paths);
        iTween.DrawPath(targetPaths);
    }
}
