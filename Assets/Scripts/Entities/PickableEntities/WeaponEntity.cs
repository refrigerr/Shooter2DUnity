using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEntity : APickable
{
    [SerializeField] private int _index;
    protected override void OnPickUp(Collider2D collider2D)
    {
        collider2D.GetComponent<WeaponManager>().UnlockWeapon(_index);
    }
  
}
