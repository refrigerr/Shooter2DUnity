using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBullet : Projectile
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision2D){
        if(_fromPlayer && collision2D.gameObject.CompareTag("Player"))
            return;
        IDamageable damageable = collision2D.gameObject.GetComponent<IDamageable>();
        damageable?.takeDamage(_damage);
        Destroy(gameObject);
    }
}
