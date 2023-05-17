using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatformButton : AInteractable
{
    public override void PerformAction()
    {
        transform.parent.GetComponent<ButtonMovablePlatform>().isMoving = true;

    }
}
