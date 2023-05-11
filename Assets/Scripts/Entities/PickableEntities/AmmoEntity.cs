using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoEntity : APickable
{
    [SerializeField] private int _ammoType;
    [SerializeField] private int _minAmmo;
    [SerializeField] private int _maxAmmo;
 
    protected override void OnPickUp(Collider2D collider2D)
    {
        collider2D.GetComponent<AmmunitionManager>().ChangeAmmoValue(_ammoType, Random.Range(_minAmmo,_maxAmmo));
    }
}
