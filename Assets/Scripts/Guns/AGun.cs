using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AGun : MonoBehaviour
{
    [SerializeField] public GunData _gunData;
    [SerializeField] protected Transform _muzzle;
    [SerializeField] public Sprite ammoTypeSprite;
    [SerializeField] protected int _ammoTypeGunUses;
    protected AmmunitionManager _ammunitionManager;
    protected float _timeSinceLastShot;
    protected float _reloadTimeProgress;
    void Awake()
    {
        _ammunitionManager = GameObject.Find("Player").GetComponent<AmmunitionManager>();
    }
    
    public abstract void Shoot(bool shootRight);

    public abstract void UpdateReloadingProgress();

    public virtual bool CanShoot()
    {
         return !_gunData.reloading && _gunData.currentAmmo > 0 && _timeSinceLastShot > 1f / (_gunData.fireRate / 60f);
    }
    

    public void StartReloading()
    {
         if(!_gunData.reloading && _gunData.currentAmmo < _gunData.magSize && _ammunitionManager.GetAmmoValue(_ammoTypeGunUses) > 0)
            _gunData.reloading = true;
    }
    
    public void InterruptReloading()
    {
        _gunData.reloading=false;
        _reloadTimeProgress=0;
    }
    public int GetAmmoTypeUsedByGun(){
        return _ammoTypeGunUses;
    }
  
}
