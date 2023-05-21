using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : AInteractable
{
    [SerializeField] private ShopWindow _shopWindow;
    public override void PerformAction(){
        _shopWindow.OpenWindow();
    }
}
