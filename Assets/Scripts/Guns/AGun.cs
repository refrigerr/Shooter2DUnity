using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AGun : MonoBehaviour
{
    [SerializeField] public GunData _gunData;
    [SerializeField] protected Transform _muzzle;
    [SerializeField] protected AmmunitionManager _ammunitionManager;
    protected float _timeSinceLastShot;
    public float _reloadTimeProgress;
    void Awake()
    {
        //_ammunitionManager = GameObject.Find("Player").GetComponent<AmmunitionManager>();
    }
    
    public abstract void Shoot(bool shootRight);

    public abstract void UpdateReloadingProgress();

    public virtual bool CanShoot()
    {
         return !_gunData.reloading && _gunData.currentAmmo - _gunData.ammoPerShot >=0 && _timeSinceLastShot > 1f / (_gunData.fireRate / 60f);
    }
    

    public virtual void StartReloading()
    {
        if(!_gunData.reloading && _gunData.currentAmmo < _gunData.magSize && _ammunitionManager.GetAmmoValue((int)_gunData.ammoType) > 0)
            _gunData.reloading = true;
    }
    
    public void InterruptReloading()
    {
        _gunData.reloading=false;
        _reloadTimeProgress=0;
    }
    public AmmunitionManager.AmmunitionType GetAmmoType(){
        return _gunData.ammoType;
    }
    
  
}
