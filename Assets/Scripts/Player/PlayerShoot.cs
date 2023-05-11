using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerShoot : MonoBehaviour
{
    private WeaponManager _weaponManager;
    private PlayerMovement _playerMovement;
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _weaponHolder;
    private Vector2 _direction, _mousePos;
    private void Awake()
    {
        _weaponManager = _player.GetComponent<WeaponManager>();
        _playerMovement =  _player.GetComponent<PlayerMovement>();
    }

    private void Update()
    {

        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _direction = _mousePos - (Vector2) _weaponHolder.position;
        FaceMouse();

        if(Input.GetMouseButton(0)){
            AGun gun = _weaponManager.currentWeapon.GetComponent<AGun>();
            gun.Shoot(_playerMovement.FacesRight());
        }

        if(Input.GetKeyDown(KeyCode.R)){
            AGun gun = _weaponManager.currentWeapon.GetComponent<AGun>();
            gun.StartReloading();
            _weaponManager.SetReloadProgressActive();
        }

    }
    private void FaceMouse()
    {
        if(_playerMovement.FacesRight() && _mousePos.x >= _player.transform.position.x){
            _weaponHolder.transform.right = _direction;
        }else if(!_playerMovement.FacesRight() && _mousePos.x <= _player.transform.position.x){
            _weaponHolder.transform.right = -_direction;
        }
    }
}
