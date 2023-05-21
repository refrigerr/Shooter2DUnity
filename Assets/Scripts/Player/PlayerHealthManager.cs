using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour, IDamageable
{

    [SerializeField] private int _health;
    private float _invincibilityTimer;
    [SerializeField] private float _invincibilityDuration;
    [SerializeField] private UIHealthDisplay _UIhealthDisplay;
    private bool _damaged;
    public void TakeDamage(int damage, AmmunitionManager.AmmunitionType cos = AmmunitionManager.AmmunitionType.PistolAmmo){
        if(_damaged)
            return;
        _health--;
        _damaged = true;
        _UIhealthDisplay.SetHealth(_health);
        
    }

    void Start()
    {
        _health = 3;
        _damaged = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(_damaged){
            _invincibilityTimer += Time.deltaTime;
            if(_invincibilityTimer>_invincibilityDuration){
                _invincibilityTimer = 0;
                _damaged = false;
            }
        }   
    }
    public int GetHealth(){
        return _health;
    }
    
}
