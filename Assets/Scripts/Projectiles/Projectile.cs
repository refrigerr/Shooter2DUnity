using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    protected int _damage;
    protected bool _fromPlayer = true;

    public void setDamage(int damage){
        this._damage = damage;
    }
    public void setFromPlayer(bool fromPlayer){
        _fromPlayer = fromPlayer;
    }
}
