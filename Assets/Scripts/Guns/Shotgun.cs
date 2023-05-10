using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : AGun
{
    [SerializeField] private GameObject _player;
    private bool _shot;
    public override void Shoot(bool shootRight){
        if (CanShoot())
        {
            if(_shot)
                return;

            for(int i=0;i<8;i++){
                GameObject bullet = Instantiate(_gunData.bullet, _muzzle.position, _muzzle.rotation);
                bullet.transform.Rotate(Vector3.forward, AngleToRotateBullet(i));
                if(shootRight){
                    bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.right * _gunData.bulletSpeed); 
                } 
                else
                    bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.right * (-_gunData.bulletSpeed));

                bullet.GetComponent<Projectile>().setDamage(_gunData.damage);
                Destroy(bullet, _gunData.bulletAliveInSeconds);
            }

            _gunData.currentAmmo--;
            _timeSinceLastShot = 0;
            _shot = true;
        } 
    }

    public override void UpdateReloadingProgress()
    {
        //increases time that passed
        _reloadTimeProgress += Time.deltaTime;
        //if time that passed is greater than reload time, perform reload
        if(_reloadTimeProgress > _gunData.reloadTime){
            if(_ammunitionManager.GetAmmoValue(_ammoTypeGunUses) > 0){
                _ammunitionManager.ChangeAmmoValue(_ammoTypeGunUses, -1);
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

    private float AngleToRotateBullet(int index)
    {
        float angle = 5;
        angle += Mathf.Floor(index/2)*5;
        angle += Random.Range(-2,2);
        if(index%2==1)
            angle = -angle;

        return angle;
    }
}
