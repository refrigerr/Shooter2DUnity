using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBullet : Projectile
{
    [SerializeField] private GameObject _explosion;
    private float _time;
    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        if(_time<0.1f)
            _time+=Time.deltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //rotates object so it naturally falls
        var angle = Mathf.Atan2(this.GetComponent<Rigidbody2D>().velocity.y,this.GetComponent<Rigidbody2D>().velocity.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnCollisionEnter2D(Collision2D collision2D){
        if(collision2D.gameObject.CompareTag("Player") && _time < 0.1f)
            return;
        GameObject explosion = Instantiate(_explosion, this.transform.position, Quaternion.identity);
        explosion.GetComponent<Explosion>().Radius = 2;
        explosion.GetComponent<Explosion>().Damage = this._damage;
        Destroy(gameObject);
    }
}
