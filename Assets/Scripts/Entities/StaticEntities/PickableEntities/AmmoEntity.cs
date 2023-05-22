using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoEntity : APickable
{
    [SerializeField] private AmmunitionManager.AmmunitionType _ammoType;
    [SerializeField] private int _minAmmo;
    [SerializeField] private int _maxAmmo;
 
    protected override void OnPickUp(Collider2D collider2D)
    {
        collider2D.GetComponent<AmmunitionManager>().ChangeAmmoValue((int)_ammoType, Random.Range(_minAmmo,_maxAmmo));
        Destroy(this.gameObject);
    }
}
