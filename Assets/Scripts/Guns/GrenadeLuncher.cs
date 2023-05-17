using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLuncher : AGun
{
    private bool _shot;
    public override void Shoot(bool shootRight)
    {
        if (CanShoot())
        {
            if(_shot)
                return;
                
            Vector3 rotation = _muzzle.rotation.eulerAngles;
            if(!shootRight)
                rotation.z += 180;

            GameObject projectile = Instantiate(_gunData.projectile, _muzzle.position, Quaternion.Euler(rotation));

            if(projectile.GetComponent<Rigidbody2D>())
                projectile.GetComponent<Rigidbody2D>().AddForce(projectile.transform.right * _gunData.projectileSpeed);

            projectile.GetComponent<Projectile>().SetVariables(_gunData.damage, true, _gunData.ammoType);

            Destroy(projectile, _gunData.projectileAliveInSeconds);

            _gunData.currentAmmo -= _gunData.ammoPerShot;
            _timeSinceLastShot = 0;
            _shot = true;
        } 
    }
    public override void UpdateReloadingProgress(){
        //increases time that passed
        _reloadTimeProgress += Time.deltaTime;
        //if time that passed is greater than reload time, perform reload
        if(_reloadTimeProgress > _gunData.reloadTime){
            if(_ammunitionManager.GetAmmoValue((int)_gunData.ammoType) > 0){
                _ammunitionManager.ChangeAmmoValue((int)_gunData.ammoType, -1);
                _gunData.currentAmmo++;
            }else
                InterruptReloading();
            _reloadTimeProgress = 0;
            if(_gunData.currentAmmo == _gunData.magSize)
                InterruptReloading();  
        }
    }
    private void Update()
    {
        //update time since last shot
        _timeSinceLastShot += Time.deltaTime;

        //if shoots one by one and already shot and mouse button released then release trigger
        if(_shot && !Input.GetMouseButton(0))
            _shot = false; 

        //updates if gun is being reloaded
        if(_gunData.reloading){
            UpdateReloadingProgress();
        }
    }
}
