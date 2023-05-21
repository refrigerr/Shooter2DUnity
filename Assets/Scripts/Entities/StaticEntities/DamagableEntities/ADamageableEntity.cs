using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class ADamageableEntity : MonoBehaviour, IDamageable
{
    [SerializeField] private int _maxHealth;
    private int _currentHealth;
    [SerializeField] private GameObject _damageText;
    [SerializeField] private AmmunitionManager.AmmunitionType[] _ammoWeakTo;
    [SerializeField] private AmmunitionManager.AmmunitionType[] _ammoResistantTo;

    //variables to display which ammo type is entity resistant/weak to
    [SerializeField] private GameObject _weakOrResistantImage;
    [SerializeField] private Sprite _weak;
    [SerializeField] private Sprite _resistant;
    private Transform _entityUI;
    private float _entityUIScale;
    //
    private CustomSlider _healthBar;
    
    private void Awake(){
        
        _healthBar = GetComponentInChildren<CustomSlider>();
        _entityUI = this.transform.GetChild(0);
    }
    private void Start(){
        _currentHealth = _maxHealth;
        _entityUIScale = _entityUI.localScale.x;
        if(_healthBar){
            _healthBar.gameObject.SetActive(false);
        }
        CreateImages();
        
    }
    //creates images to display which ammo type is entity weak/resistant to
    private void CreateImages()
    {
        int i = 0;

        foreach(AmmunitionManager.AmmunitionType ammunitionType in _ammoWeakTo)
        {
            GameObject image = Instantiate(_weakOrResistantImage, _healthBar.transform.position + new Vector3(-0.4f + 0.4f*i,0.3f,0), Quaternion.identity);
            image.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = AmmunitionManager.GetAmmoSprite(((int)ammunitionType));
            image.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = _weak;
            image.transform.parent = _entityUI;
            i++;

        }
        foreach(AmmunitionManager.AmmunitionType ammunitionType in _ammoResistantTo)
        {
            GameObject image = Instantiate(_weakOrResistantImage, _healthBar.transform.position + new Vector3(-0.4f + 0.4f*i,0.3f,0), Quaternion.identity);
            image.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = AmmunitionManager.GetAmmoSprite(((int)ammunitionType));
            image.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = _resistant;
            image.transform.parent = _entityUI;
            i++;

        }

    }

    public void TakeDamage(int damage, AmmunitionManager.AmmunitionType ammoType){
        int damageToTake = damage;
        if(Array.Exists(_ammoWeakTo, x => x == ammoType))
            damageToTake*=2;
        if(Array.Exists(_ammoResistantTo, x => x == ammoType))
            damageToTake/=2;

        _currentHealth -= damageToTake;
        ShowDamage(damageToTake.ToString());
        if(_healthBar){
            if(!_healthBar.gameObject.activeSelf){}
                _healthBar.gameObject.SetActive(true);
            _healthBar.UpdateHealthBar(_currentHealth, _maxHealth);
        }
            
        if(_currentHealth<=0){
            DoOnDeath();
            Destroy(gameObject);
        } 
    }

    protected abstract void DoOnDeath();

    private void ShowDamage(string sDamage){
        if(_damageText){
            GameObject damageToShow = Instantiate(_damageText, this.transform.position + new Vector3(0,this.transform.lossyScale.y/2,0), Quaternion.identity);
            damageToShow.GetComponentInChildren<TextMesh>().text = sDamage;
            Destroy(damageToShow, 1f);
        }
        
    }
    void Update()
    {
       ScaleEntityUI();
    }
    public void ScaleEntityUI()
    {
         _entityUI.localScale = new Vector3(this.transform.localScale.x > 0 ? _entityUIScale : -_entityUIScale ,_entityUI.localScale.y ,_entityUI.localScale.z);
    }

}
