using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Projectile
{
    private LineRenderer _lineRenderer;
    [SerializeField] private BoxCollider2D _boxCollider2D;
    private Collider2D[] _colliders2D;
    private float _alpha;
    private bool _didDamage;

    // Start is called before the first frame update
    void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
       //_boxCollider2D= GetComponent<BoxCollider2D>();
    }
    void Start (){
        _alpha = 1;
        _didDamage = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(_alpha<1 && !_didDamage)
            _didDamage = true;
            
        //fading laser
        _alpha-=Time.deltaTime;
        Color color = new Color(1f,1f,1f,_alpha);
        _lineRenderer.startColor=color;
        _lineRenderer.endColor=color;

        if(_alpha<=0){
            //Destroy(this.gameObject);
        }

        OnTriggerEnter2D(_boxCollider2D);
        _didDamage = true;
        
    }
    

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(_didDamage)
            return;

        if(_fromPlayer && collider2D.gameObject.CompareTag("Player"))
            return;
        if(collider2D.gameObject.GetComponent<Projectile>() != null)
            return;
        
        IDamageable damageable = collider2D.gameObject.GetComponent<IDamageable>();
        damageable?.takeDamage(_damage, this._ammoType);
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.black;
        Gizmos.DrawWireCube(new Vector2(_boxCollider2D.bounds.center.x,_boxCollider2D.bounds.center.y), new Vector2(_boxCollider2D.bounds.size.x,_boxCollider2D.bounds.size.y));
        //Gizmos.DrawWireCube(transform.position, new Vector3(1, 1, 1));

    }
}
