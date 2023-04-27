using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public byte _weaponsUnlocked = 3;
    public int _currentWeaponIndex = 0;
    public GameObject[] _weapons;
    [SerializeField] public GameObject _weaponHolder;
    public GameObject _currentWeapon;
    // Start is called before the first frame update
    void Start()
    {
        _weapons = new GameObject[_weaponHolder.transform.childCount-1];
        for(int i=0; i<_weapons.Length;i++){
            _weapons[i] = _weaponHolder.transform.GetChild(i+1).gameObject;
            Debug.Log(_weapons[i].name);
            _weapons[i].SetActive(false);
        }
        _weapons[0].SetActive(true);
        _currentWeapon = _weapons[0];
        _currentWeaponIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        SwitchingWeapons();
        
    }

    private void SwitchingWeapons(){
        if(Input.GetKeyDown(KeyCode.Alpha1) && _currentWeaponIndex!=0){
            SetWeaponActive(0);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2) && _currentWeaponIndex!=1){
            SetWeaponActive(1);
        }
        /*
        if(Input.GetKeyDown(KeyCode.Keypad3) && _currentWeaponIndex!=0){
            _weapons[_currentWeaponIndex].SetActive(false);
            _currentWeaponIndex = 0;
            _weapons[_currentWeaponIndex].SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.Keypad4) && _currentWeaponIndex!=0){
            _weapons[_currentWeaponIndex].SetActive(false);
            _currentWeaponIndex = 0;
            _weapons[_currentWeaponIndex].SetActive(true);
        }
        if(Input.GetKeyDown(KeyCode.Keypad5) && _currentWeaponIndex!=0){
            _weapons[_currentWeaponIndex].SetActive(false);
            _currentWeaponIndex = 0;
            _weapons[_currentWeaponIndex].SetActive(true);
        }
        */
    }

    private void SetWeaponActive(int index){
        _weapons[_currentWeaponIndex].GetComponent<AGun>().FinishReloading();
        _weapons[_currentWeaponIndex].SetActive(false);
        _currentWeaponIndex = index;
        _weapons[_currentWeaponIndex].SetActive(true);
        _currentWeapon = _weapons[_currentWeaponIndex];
    }

}
