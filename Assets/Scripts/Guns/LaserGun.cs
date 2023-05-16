using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : AGun
{
    [SerializeField] private float _chargeTime;
    [SerializeField] private float _chargeProgress;
    [SerializeField] private GameObject _laser;

    public override void Shoot(bool shootRight){
        if (CanShoot())
        {
            Vector3 rotation = _muzzle.rotation.eulerAngles;
            if(!shootRight)
                rotation.z += 180;
            GameObject laser = Instantiate(_laser,_muzzle.position,Quaternion.Euler(rotation));
            _chargeProgress = 0;
        }
        else if(!_gunData.reloading && _gunData.currentAmmo > 0){
            _chargeProgress += Time.deltaTime;

        }
    }
    public override void UpdateReloadingProgress(){
        //increases time that passed
        _reloadTimeProgress += Time.deltaTime;
        //if time that passed is greater than reload time, perform reload
        if(_reloadTimeProgress > _gunData.reloadTime){
            _gunData.currentAmmo = _gunData.magSize;
            InterruptReloading();
        }
    }
    private void Update(){
        //update time since last shot
        _timeSinceLastShot += Time.deltaTime;

        if(Input.GetMouseButtonUp(0)){
            _chargeProgress = 0;
        }
            
        //updates if gun is being reloaded
        if(_gunData.reloading){
            UpdateReloadingProgress();
        }

       
    }

    public override bool CanShoot(){
         return !_gunData.reloading && _gunData.currentAmmo > 0 && _chargeProgress >= _chargeTime;
    } 
}
