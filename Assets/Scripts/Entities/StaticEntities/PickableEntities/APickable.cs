using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class APickable : MonoBehaviour
{
    private Transform _spriteRenderer;
    private float _startY;
    private float _offestY;

    void Awake(){
        _spriteRenderer = this.transform.GetChild(0);
        _startY = _spriteRenderer.transform.position.y;
    }

    void FixedUpdate(){
        _offestY += Time.deltaTime;
        if(_offestY>2*Mathf.PI)
            _offestY = 0;
        _spriteRenderer.position = new Vector3(_spriteRenderer.position.x, _startY + Mathf.Sin(_offestY) *0.2f, 0);
    }

    void OnTriggerEnter2D(Collider2D collider2D){
        if(!collider2D.gameObject.CompareTag("Player"))
            return;
        OnPickUp(collider2D);
        Destroy(this.gameObject);
    }
    protected abstract void OnPickUp(Collider2D collider2D);
}
