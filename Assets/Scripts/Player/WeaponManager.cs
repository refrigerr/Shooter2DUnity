using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public int _weaponsUnlocked = 0;
    public int currentWeaponIndex = 0;
    public GameObject[] weapons;
    [SerializeField] public GameObject weaponHolder;
    [SerializeField] public UIAmmunitionDisplay UIAmmunitionDisplay;
    [SerializeField] public UIWeaponDisplay UIWeaponDisplay;
    public GameObject currentWeapon;
    // Start is called before the first frame update
    void Awake()
    {
        weapons = new GameObject[weaponHolder.transform.childCount-1];
        for(int i=0; i<weapons.Length;i++){
            weapons[i] = weaponHolder.transform.GetChild(i+1).gameObject;
            weapons[i].SetActive(false);

        }
        weapons[0].SetActive(true);
        currentWeapon = weapons[0];
        currentWeaponIndex = 0;
    }


    // Update is called once per frame
    void Update()
    {
        SwitchingWeapons(); 
    }

    private void SwitchingWeapons(){
        if(Input.GetKeyDown(KeyCode.Alpha1) && currentWeaponIndex!=0 && ((_weaponsUnlocked & 1) != 0)){
            SetWeaponActive(0);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2) && currentWeaponIndex!=1 && ((_weaponsUnlocked & 2) != 0) ){
            SetWeaponActive(1);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3) && currentWeaponIndex!=2 && ((_weaponsUnlocked & 4) != 0)){
            SetWeaponActive(2);
        }
        if(Input.GetKeyDown(KeyCode.Alpha4) && currentWeaponIndex!=3 && ((_weaponsUnlocked & 8) != 0)){
            SetWeaponActive(3);
        }
    }

    public void UnlockWeapon(int index){
        int a = 1 << index;
        _weaponsUnlocked = _weaponsUnlocked | a;

    }

    private void SetWeaponActive(int index){
        weapons[currentWeaponIndex].GetComponent<AGun>().InterruptReloading();
        weapons[currentWeaponIndex].SetActive(false);
        currentWeaponIndex = index;
        weapons[currentWeaponIndex].SetActive(true);
        currentWeapon = weapons[currentWeaponIndex];

        //UI update
        UIAmmunitionDisplay.UpdateWeapon();
        UIWeaponDisplay.ChangeHighLightPosition(currentWeaponIndex);
    }

}
