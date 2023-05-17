using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : AGun
{
    [SerializeField] private float _chargeTime;
    [SerializeField] private float _chargeProgress;
    [SerializeField] private GameObject _particleSystem;

    void Awake(){
        _particleSystem.SetActive(false);
    }

    public override void Shoot(bool shootRight){
        if (CanShoot())
        {
            Vector3 rotation = _muzzle.rotation.eulerAngles;
            if(!shootRight)
                rotation.z += 180;
            GameObject projectile = Instantiate(_gunData.projectile,_muzzle.position,Quaternion.Euler(rotation));

            if(projectile.GetComponent<Rigidbody2D>())
                projectile.GetComponent<Rigidbody2D>().AddForce(projectile.transform.right * _gunData.projectileSpeed);
                
            projectile.GetComponent<Projectile>().SetVariables(_gunData.damage, true, _gunData.ammoType);
            _chargeProgress = 0;
            _gunData.currentAmmo -= _gunData.ammoPerShot;
        }
        else if(!_gunData.reloading && _gunData.currentAmmo - _gunData.ammoPerShot >=0){

            _chargeProgress += Time.deltaTime;

            if(!_particleSystem.activeSelf)
                _particleSystem.SetActive(true);

        }
    }
    public override void UpdateReloadingProgress(){
        //increases time that passed
        _reloadTimeProgress += Time.deltaTime;
        //if time that passed is greater than reload time, perform reload
        if(_reloadTimeProgress >= _gunData.reloadTime){
            if(_ammunitionManager.GetAmmoValue((int)_gunData.ammoType) >= _gunData.magSize - _gunData.currentAmmo){
                _ammunitionManager.ChangeAmmoValue((int)_gunData.ammoType, -(_gunData.magSize - _gunData.currentAmmo));
                _gunData.currentAmmo = _gunData.magSize;
            }else{
                _gunData.currentAmmo += _ammunitionManager.GetAmmoValue((int)_gunData.ammoType);
                _ammunitionManager.ChangeAmmoValue((int)_gunData.ammoType, -_ammunitionManager.GetAmmoValue((int)_gunData.ammoType));
            }
            
            InterruptReloading();
        }
    }
    private void Update(){
        //update time since last shot
        _timeSinceLastShot += Time.deltaTime;

        if(!Input.GetMouseButton(0)){
            _chargeProgress = 0;
            if(_particleSystem.activeSelf)
                _particleSystem.SetActive(false);
        }
            
        //updates if gun is being reloaded
        if(_gunData.reloading){
            UpdateReloadingProgress();
        }

       
    }

    public override bool CanShoot(){
         return !_gunData.reloading && _gunData.currentAmmo - _gunData.ammoPerShot >=0 && _chargeProgress >= _chargeTime;
    } 
}
