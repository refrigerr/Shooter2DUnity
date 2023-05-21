using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
            
    }
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        if(_fromPlayer && collision2D.gameObject.CompareTag("Player"))
            return;
        if(collision2D.gameObject.GetComponent<Projectile>() != null)
            return;
        IDamageable damageable = collision2D.gameObject.GetComponent<IDamageable>();
        damageable?.TakeDamage(_damage, this._ammoType);
        Destroy(gameObject);
    }
}
