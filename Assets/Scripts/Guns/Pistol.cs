using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : AGun
{
    private bool _shot;
    public override void Shoot(bool shootRight){
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
            _shot = true;
        } 
    }
    public override void UpdateReloadingProgress(){
        //increases time that passed
        _reloadTimeProgress += Time.deltaTime;
        //if time that passed is greater than reload time, perform reload
        if(_reloadTimeProgress > _gunData.reloadTime){
            _gunData.currentAmmo = _gunData.magSize;
            FinishReloading();
            
            /*
      
            gunData.currentAmmo += 1;
            _reloadTimeProgress = 0;
            if(gunData.currentAmmo == gunData.magSize)
                FinishReloading();
        
            */
        }
    }
    private void Update(){
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
