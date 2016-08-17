using UnityEngine;
using System.Collections;

public class Camera_Move : MonoBehaviour {

    public Transform[] paths;

    [HideInInspector] public Character character;

    private int _currentPath = 0;
    private int _nextPath;

    void FixedUpdate()
    {
        if (character.isMoving)
        {
            iTween.Resume();
            if (_currentPath == _nextPath)
            {
                _nextPath++;
                iTween.MoveTo(gameObject, iTween.Hash("position", paths[_nextPath].position, "speed", 10, "easeType", "linear"));
            }
            if (paths[_nextPath].position.x <= transform.position.x)
            {
                _currentPath = _nextPath;
            }
        }
        else
        {
            iTween.Pause();
        }
    }
}
