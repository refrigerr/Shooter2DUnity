using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AGun : MonoBehaviour
{
    [SerializeField] protected GunData _gunData;
    [SerializeField] protected Transform _muzzle;

    protected float _timeSinceLastShot;
    protected float _reloadTimeProgress;

    public abstract void Shoot(bool shootRight);

    public abstract void UpdateReloadingProgress();

    public void StartReloading(){
         if(!_gunData.reloading && _gunData.currentAmmo < _gunData.magSize)
            _gunData.reloading = true;
    }
    
    public  void FinishReloading(){
        _gunData.reloading=false;
        _reloadTimeProgress=0;
    }

    public bool CanShoot(){
         return !_gunData.reloading && _gunData.currentAmmo > 0 && _timeSinceLastShot > 1f / (_gunData.fireRate / 60f);
    }
    
}
