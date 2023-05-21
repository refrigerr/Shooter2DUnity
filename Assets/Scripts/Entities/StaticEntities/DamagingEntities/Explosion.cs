using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float Radius {get; set;}
    public int Damage {get;set;}
    private bool _didDamage;

    void Start()
    {
        _didDamage = false;
        Destroy(gameObject, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(!_didDamage){
            Collider2D[] objectsHit = Physics2D.OverlapCircleAll(this.transform.position, Radius);

            foreach(Collider2D collider2D in objectsHit){

                IDamageable damageable = collider2D.gameObject.GetComponent<IDamageable>();
                damageable?.takeDamage(Damage, AmmunitionManager.AmmunitionType.ExplosiveAmmo);

            }
            _didDamage = true;
        }
        
        
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(this.transform.position, Radius);
    }
}
