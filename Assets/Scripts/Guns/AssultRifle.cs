using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssultRifle : AGun
{
    public override void Shoot(bool shootRight)
    {
        if (CanShoot())
        {
            GameObject bullet = Instantiate(_gunData.bullet, _muzzle.position, _muzzle.rotation);
            if(shootRight)
                bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.right * _gunData.bulletSpeed);
            else
                bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.right * (-_gunData.bulletSpeed));
            bullet.GetComponent<Projectile>().setVariables(_gunData.damage, true, _gunData.ammoType);

            Destroy(bullet, _gunData.bulletAliveInSeconds);
            
            _gunData.currentAmmo--;
            _timeSinceLastShot = 0;
         
        } 
    }
    public override void UpdateReloadingProgress()
    {
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
    private void Update()
    {
        //update time since last shot
        _timeSinceLastShot += Time.deltaTime; 

        //updates if gun is being reloaded
        if(_gunData.reloading){
            UpdateReloadingProgress();
        }
    }
}
