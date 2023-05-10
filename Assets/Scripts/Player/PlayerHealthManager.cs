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
    public void takeDamage(int damage){
        if(_damaged)
            return;
        _health -= 1;
        _damaged = true;
        _UIhealthDisplay.setHealth(_health);
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
    public int getHealth(){
        return _health;
    }
}
