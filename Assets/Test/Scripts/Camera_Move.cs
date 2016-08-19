using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Camera_Move : MonoBehaviour {

    public Transform[] paths;

    [HideInInspector] public Character character;

    private int _currentPath = 0;
    private int _nextPath;
    private float _currentPathPercent = 0.0f; // min 0, max 1
    private List<Camera_Spot> spots = new List<Camera_Spot>();

    public void Initialize()
    {
        _nextPath = _currentPath++;
        foreach(Transform tmp in paths)
        {
            spots.Add(tmp.gameObject.GetComponent<Camera_Spot>());
        }
    }

    void Update()
    {
        float __off = paths[paths.Length - 1].position.x - paths[0].position.x;
        _currentPathPercent = ((character.transform.position.x - paths[0].position.x) / __off);
        iTween.PutOnPath(gameObject, paths, _currentPathPercent);
        if(transform.position.x >= paths[_nextPath].position.x)
        {
            _currentPath = _nextPath;
            spots[_currentPath].SpotAction(character);
            if (_nextPath < paths.Length-1)
            {
                _nextPath++;
            }
        }
    }

    void OnDrawGizmos()
    {
        iTween.DrawPath(paths);
    }
}
