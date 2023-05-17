using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    protected int _damage;
    protected bool _fromPlayer = true;
    protected AmmunitionManager.AmmunitionType _ammoType;

    public void SetVariables(int damage, bool fromPlayer, AmmunitionManager.AmmunitionType ammoType){
        this._damage = damage;
        this._fromPlayer = fromPlayer;
        this._ammoType = ammoType;
    }

}
