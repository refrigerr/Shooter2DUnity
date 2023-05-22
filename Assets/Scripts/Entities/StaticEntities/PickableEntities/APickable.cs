using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class APickable : MonoBehaviour
{
    private Transform _spriteRenderer;
    private float _offestY;
    private BoxCollider2D _boxCollider2D;
    [SerializeField] private LayerMask _obstacleLayer;

    void Awake(){
        this.transform.parent = GameObject.Find("PickableEntities").transform;
        _spriteRenderer = this.transform.GetChild(0);
        _boxCollider2D = this.GetComponent<BoxCollider2D>();
    }

    void FixedUpdate(){
        _offestY += Time.deltaTime;
        if(_offestY>2*Mathf.PI)
            _offestY = 0;
        _spriteRenderer.position = new Vector3(_spriteRenderer.position.x, this.transform.position.y + Mathf.Sin(_offestY) *0.2f, 0);

        if(!isGrounded())
            this.transform.position =  this.transform.position - new Vector3(0,Time.deltaTime);
        
    }

    void OnTriggerEnter2D(Collider2D collider2D){
        if(!collider2D.gameObject.CompareTag("Player"))
            return;
        OnPickUp(collider2D);
    }
    protected abstract void OnPickUp(Collider2D collider2D);

    private bool isGrounded()
    {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(_boxCollider2D.bounds.center,_boxCollider2D.bounds.size, 0 , Vector2.down, 0.1f, _obstacleLayer);
        return raycastHit2D.collider != null;
    }
}
