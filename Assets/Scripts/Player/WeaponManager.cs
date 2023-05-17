using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public int weaponsUnlocked;
    public int currentWeaponIndex;
    private GameObject[] weapons;
    [SerializeField] private GameObject _weaponHolder;
    [SerializeField] private UIAmmunitionDisplay _UIAmmunitionDisplay;
    [SerializeField] private UIWeaponDisplay _UIWeaponDisplay;
    private CustomSlider _realoadProgress;
    public GameObject currentWeapon;
    // Start is called before the first frame update
    void Awake()
    {
        _realoadProgress = GetComponentInChildren<CustomSlider>();
    
    }
    void Start()
    {
        weapons = new GameObject[_weaponHolder.transform.childCount-1];
            for(int i=0; i<weapons.Length;i++){
                weapons[i] = _weaponHolder.transform.GetChild(i+1).gameObject;
                weapons[i].SetActive(false);

            }
        weapons[0].SetActive(true);
        currentWeapon = weapons[0];
        currentWeaponIndex = 0;
        weaponsUnlocked = 1;

        _realoadProgress.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        SwitchingWeapons(); 
        ShowReloadProgress();  
    }

    private void SwitchingWeapons()
    {
        
        

        if(Input.GetKeyDown(KeyCode.Alpha1) && currentWeaponIndex!=0 && ((weaponsUnlocked & 1) != 0)){
            SetWeaponActive(0);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2) && currentWeaponIndex!=1 && ((weaponsUnlocked & 2) != 0) ){
            SetWeaponActive(1);
        }
        if(Input.GetKeyDown(KeyCode.Alpha3) && currentWeaponIndex!=2 && ((weaponsUnlocked & 4) != 0)){
            SetWeaponActive(2);
        }
        if(Input.GetKeyDown(KeyCode.Alpha4) && currentWeaponIndex!=3 && ((weaponsUnlocked & 8) != 0)){
            SetWeaponActive(3);
        }
        if(Input.GetKeyDown(KeyCode.Alpha5) && currentWeaponIndex!=4 && ((weaponsUnlocked & 16) != 0)){
            SetWeaponActive(4);
        }
        if(Input.GetKeyDown(KeyCode.Alpha6) && currentWeaponIndex!=5 && ((weaponsUnlocked & 32) != 0)){
            SetWeaponActive(5);
        }
        if(Input.GetKeyDown(KeyCode.Alpha7) && currentWeaponIndex!=6 && ((weaponsUnlocked & 64) != 0)){
            SetWeaponActive(6);
        }
        if(Input.GetKeyDown(KeyCode.E)){
            SetWeaponActive(GetNextWeapon(currentWeaponIndex));
        }
        if(Input.GetKeyDown(KeyCode.Q)){
            SetWeaponActive(GetPreviousWeapon(currentWeaponIndex));
        }
    }


    private void ShowReloadProgress()
    {
         if(currentWeapon.GetComponent<AGun>()._gunData.reloading){
            _realoadProgress.UpdateHealthBar(currentWeapon.GetComponent<AGun>()._reloadTimeProgress, currentWeapon.GetComponent<AGun>()._gunData.reloadTime);
             _realoadProgress.GetComponent<RectTransform>().localScale = new Vector3(this.transform.localScale.x > 0 ? 1 : -1 ,1 ,1);
         }else{
            if(_realoadProgress.gameObject.activeSelf)
                _realoadProgress.gameObject.SetActive(false); 
         }
    }
    public void SetReloadProgressActive()
    {
        _realoadProgress.gameObject.SetActive(true);
    }

    private int GetNextWeapon(int index)
    {
        if(weaponsUnlocked==0)
            return 0;
        int nextIndex = index + 1;
        if(nextIndex > weapons.Length)
            return 0;
        if((weaponsUnlocked & 1 << nextIndex) != 0)
            return nextIndex;
        else
            return GetNextWeapon(nextIndex);
    }

    private int GetPreviousWeapon(int index)
    {
        if(weaponsUnlocked==0)
            return 0;
            
        int nextIndex = index - 1;
        if(nextIndex < 0)
            return GetPreviousWeapon(weapons.Length);
        if((weaponsUnlocked & 1 << nextIndex) != 0)
            return nextIndex;
        else
            return GetPreviousWeapon(nextIndex);
    }


    public void UnlockWeapon(int index)
    {
        int a = 1 << index;
        weaponsUnlocked = weaponsUnlocked | a;

    }

    private void SetWeaponActive(int index)
    {
        weapons[currentWeaponIndex].GetComponent<AGun>().InterruptReloading();
        weapons[currentWeaponIndex].SetActive(false);
        currentWeaponIndex = index;
        weapons[currentWeaponIndex].SetActive(true);
        currentWeapon = weapons[currentWeaponIndex];

        //UI update
        _UIAmmunitionDisplay.UpdateWeapon();
        _UIWeaponDisplay.ChangeHighLightPosition(currentWeaponIndex);
    }

}
