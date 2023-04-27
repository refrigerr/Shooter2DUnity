using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, IDamageable
{
    private int health = 100;


    public void takeDamage(int damage){
        health -= damage;
        if(health<=0)
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision2D){
        IDamageable damageable = collision2D.gameObject.GetComponent<IDamageable>();
        damageable?.takeDamage(1);
    }
}
