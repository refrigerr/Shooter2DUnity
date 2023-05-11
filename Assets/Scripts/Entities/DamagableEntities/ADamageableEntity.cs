using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ADamageableEntity : MonoBehaviour, IDamageable
{
    [SerializeField] private int _maxHealth;
    private int _currentHealth;
    [SerializeField] private GameObject _damageText;
    private CustomSlider _healthBar;
    
    private void Awake(){
        
        _healthBar = GetComponentInChildren<CustomSlider>();
    }
    private void Start(){
        _currentHealth = _maxHealth;
        _healthBar.UpdateHealthBar(_currentHealth, _maxHealth);
    }

    public void takeDamage(int damage){
        _currentHealth -= damage;
        ShowDamage(damage.ToString());
        _healthBar.UpdateHealthBar(_currentHealth, _maxHealth);
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
