using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Projectile
{
    private LineRenderer _lineRenderer;
    [SerializeField] private BoxCollider2D _boxCollider2D;
    private Collider2D[] _colliders2D;
    private float _alpha;
    private int _framesActive;

    // Start is called before the first frame update
    void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
       //_boxCollider2D= GetComponent<BoxCollider2D>();
    }
    void Start (){
        _alpha = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
  
        //fading laser
        _alpha-=Time.deltaTime;
        Color color = new Color(1f,1f,1f,_alpha);
        _lineRenderer.startColor=color;
        _lineRenderer.endColor=color;

        if(_alpha<=0){
            Destroy(this.gameObject);
        }
        if(_framesActive<=15)
            _framesActive++;
        
    }
    

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(_framesActive>15)
            return;

        if(_fromPlayer && collider2D.gameObject.CompareTag("Player"))
            return;

        if(collider2D.gameObject.GetComponent<Projectile>() != null)
            return;
        
        IDamageable damageable = collider2D.gameObject.GetComponent<IDamageable>();
        damageable?.TakeDamage(_damage, this._ammoType);
    }
}
