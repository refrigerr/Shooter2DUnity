using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : AGun
{
    [SerializeField] private float _chargeTime;
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private float _chargeProgress;
    public override void Shoot(bool shootRight){
        if (CanShoot())
        {
 

            RaycastHit2D hit2D = Physics2D.Raycast(transform.position, transform.right);
            _lineRenderer.SetPosition(0, _muzzle.position);
            if(hit2D && hit2D.transform.gameObject.CompareTag("Obstacle")){
                _lineRenderer.useWorldSpace = true;
                _lineRenderer.SetPosition(1, hit2D.point);
            }
            else{
                //_lineRenderer.useWorldSpace = false;
                _lineRenderer.SetPosition(1, Camera.main.ScreenToWorldPoint(_muzzle.transform.right * 2)); 
            }
                     
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

        if(Input.GetMouseButtonUp(0))
            _chargeProgress = 0;
            
        //updates if gun is being reloaded
        if(_gunData.reloading){
            UpdateReloadingProgress();
        }
    }

    public override bool CanShoot(){
         return !_gunData.reloading && _gunData.currentAmmo > 0 && _chargeProgress >= _chargeTime;
    } 
}
