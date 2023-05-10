using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAmmunitionDisplay : MonoBehaviour
{
    [SerializeField] private GameObject _ammunitionSprite;
    [SerializeField] private Text _currentAmmoText;
    [SerializeField] private Text _magSizeText;
    [SerializeField] private Text _ammoInStorageText;
    private WeaponManager _weaponManager;
    private AmmunitionManager _ammunitionManager;
    // Start is called before the first frame update
    void Awake()
    {
        _ammunitionManager = GameObject.Find("Player").GetComponent<AmmunitionManager>();
        _weaponManager = GameObject.Find("Player").GetComponent<WeaponManager>();
        UpdateWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(_weaponManager.currentWeaponIndex==0){
            _currentAmmoText.text = "∞";
            _ammoInStorageText.text = "∞";
            
        }else{
            _currentAmmoText.text = _weaponManager.currentWeapon.GetComponent<AGun>()._gunData.currentAmmo.ToString(); 
            _ammoInStorageText.text ="("+ _ammunitionManager.GetAmmoValue(_weaponManager.currentWeapon.GetComponent<AGun>().GetAmmoTypeUsedByGun()).ToString()+ ")";  
        }
    }

    public void UpdateWeapon(){
        _ammunitionSprite.GetComponent<Image>().sprite = _weaponManager.currentWeapon.GetComponent<AGun>().ammoTypeSprite;
        if(_weaponManager.currentWeaponIndex==0){
            _magSizeText.text = "∞";
            
        }else{
            _magSizeText.text = _weaponManager.currentWeapon.GetComponent<AGun>()._gunData.magSize.ToString();
            
        }
    }
}
