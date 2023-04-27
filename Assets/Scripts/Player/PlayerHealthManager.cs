using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour, IDamageable
{

    [SerializeField] private int _health;
    private float _invincibilityTimer;
    [SerializeField] private float _invincibilityDuration;
    private bool _damaged;
    public void takeDamage(int damage){
        if(_damaged)
            return;
        _health -= 1;
        _damaged = true;
    }

    void Start()
    {
        _damaged = false;
    }

    // Update is called once per frame
    void Update()
    {
        _invincibilityTimer += Time.deltaTime;
        if(_invincibilityTimer>_invincibilityDuration){
            _invincibilityTimer = 0;
            _damaged = false;
        }
            
        
    }
}
