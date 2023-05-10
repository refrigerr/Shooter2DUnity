using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AMovablePlatform : MonoBehaviour
{
    [SerializeField] protected Transform _platform;
    [SerializeField] protected Transform[] _points;
    protected Transform _nextPoint;
    protected int _nextPointIndex;
    [SerializeField] protected float _speed;

    // Start is called before the first frame update
    void Start()
    {    
        _platform.position = _points[0].position;
        if(_points.Length>1){
            _nextPoint = _points[1];
            _nextPointIndex = 1;
        }   
    }
  

    // Update is called once per frame
    void Update()
    {
        
    }

    protected virtual void MovePlatform()
    {
        if(_platform.position == _nextPoint.position){
            _nextPointIndex++;
            if(_nextPointIndex>=_points.Length){
                _nextPointIndex = 0;
            }
            _nextPoint = _points[_nextPointIndex];
        }
        else{
            _platform.position = Vector2.MoveTowards(_platform.position, _nextPoint.position, _speed * Time.deltaTime);
        }
    }
}
