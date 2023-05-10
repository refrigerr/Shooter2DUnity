using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMovablePlatform : AMovablePlatform
{
    public bool isMoving {get;set;}


    // Update is called once per frame
    void Update()
    {
        if(isMoving)
            MovePlatform();
    }

    protected override void MovePlatform()
    {
        if(_platform.position == _nextPoint.position){
            _nextPointIndex++;
            if(_nextPointIndex>=_points.Length){
                _nextPointIndex = 0;
            }
            _nextPoint = _points[_nextPointIndex];
            isMoving = false;
        }
        else{
            _platform.position = Vector2.MoveTowards(_platform.position, _nextPoint.position, _speed * Time.deltaTime);
        }
    }
}
