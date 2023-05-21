using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricGun : AGun
{
    [SerializeField] private float _angle;
    [SerializeField] private float _radius;
    [SerializeField] private LayerMask _obstacleLayer;
    [SerializeField] private LayerMask _ignoreLayer;
    [SerializeField] private GameObject _lightning;
     public override void Shoot(bool shootRight)
    {
        if (CanShoot())
        {
            bool shot = false;
            Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(_muzzle.position, _radius);

            foreach(Collider2D collider2D in rangeCheck){
                Vector2 directionToTarget = (collider2D.transform.position - _muzzle.position).normalized;

                if((shootRight && Vector2.Angle(transform.right, directionToTarget) < _angle / 2) || (!shootRight && Vector2.Angle(transform.right, directionToTarget) > 180 - _angle / 2)){
                    float distanceToTarget = Vector2.Distance(_muzzle.position, collider2D.transform.position);
                    RaycastHit2D obstacleHit = Physics2D.Raycast(_muzzle.position, directionToTarget, distanceToTarget, _obstacleLayer);
                    
                    if(obstacleHit && obstacleHit.transform.gameObject.GetComponent<IDamageable>() == null)
                        continue;
                    
                    
                    IDamageable damageable = collider2D.gameObject.GetComponent<IDamageable>();

                    if(damageable!= null)
                    {
                        RaycastHit2D hit2D = Physics2D.Raycast(_muzzle.position, directionToTarget, distanceToTarget, ~_ignoreLayer);
                        damageable.TakeDamage(_gunData.damage, _gunData.ammoType);
                        GameObject lightning = Instantiate(_lightning, _muzzle.position, Quaternion.identity);
                        lightning.GetComponent<LineRenderer>().SetPosition(0, Vector2.zero);
                        lightning.GetComponent<LineRenderer>().SetPosition(1, hit2D.point - (Vector2) _muzzle.position ); 
                        shot = true;
                    }

                    
                }
            } 
            if(shot){
                _gunData.currentAmmo -= _gunData.ammoPerShot;
                _timeSinceLastShot = 0;
            }
         
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

    private Vector2 DirectionFromAngle(float eulerY, float angleInDegrees){
        angleInDegrees += eulerY;
        return new Vector2(Mathf.Sin(angleInDegrees*Mathf.Deg2Rad), Mathf.Cos(angleInDegrees*Mathf.Deg2Rad));
    }
}
