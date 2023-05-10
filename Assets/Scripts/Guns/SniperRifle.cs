using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperRifle : AGun
{
    private bool _shot;
    public override void Shoot(bool shootRight)
    {
        if (CanShoot())
        {
            if(_shot)
                return;
            GameObject bullet = Instantiate(_gunData.bullet, _muzzle.position, _muzzle.rotation);
            if(shootRight)
                bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.right * _gunData.bulletSpeed);
            else
                bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.right * (-_gunData.bulletSpeed));

            bullet.GetComponent<Projectile>().setDamage(_gunData.damage);

            Destroy(bullet, _gunData.bulletAliveInSeconds);
            
            _timeSinceLastShot = 0;
            _gunData.currentAmmo--;
            _shot = true;
        } 
    }
    public override void UpdateReloadingProgress()
    {
        //increases time that passed
        _reloadTimeProgress += Time.deltaTime;
        //if time that passed is greater than reload time, perform reload
        if(_reloadTimeProgress >= _gunData.reloadTime){
            if(_ammunitionManager.GetAmmoValue(_ammoTypeGunUses) >= _gunData.magSize - _gunData.currentAmmo){
                _ammunitionManager.ChangeAmmoValue(_ammoTypeGunUses, -(_gunData.magSize - _gunData.currentAmmo));
                _gunData.currentAmmo = _gunData.magSize;
            }else{
                _gunData.currentAmmo += _ammunitionManager.GetAmmoValue(_ammoTypeGunUses);
                _ammunitionManager.ChangeAmmoValue(_ammoTypeGunUses, -_ammunitionManager.GetAmmoValue(_ammoTypeGunUses));
            }
            
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
