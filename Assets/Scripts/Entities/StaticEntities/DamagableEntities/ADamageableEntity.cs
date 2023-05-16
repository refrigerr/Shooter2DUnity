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
    private CustomSlider _healthBar;
    
    private void Awake(){
        
        _healthBar = GetComponentInChildren<CustomSlider>();
    }
    private void Start(){
        _currentHealth = _maxHealth;
        if(_healthBar)
            _healthBar.gameObject.SetActive(false);
    }

    public void takeDamage(int damage, AmmunitionManager.AmmunitionType ammoType){
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

}
