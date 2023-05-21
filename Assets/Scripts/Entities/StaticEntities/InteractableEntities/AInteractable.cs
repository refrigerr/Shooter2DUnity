using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AInteractable : MonoBehaviour
{
    private bool _isPlayerNearby = false;
    [SerializeField] private KeyCode _key;
    private Transform _text;


    void Awake(){
        _text = this.transform.GetChild(0);
        _text.GetComponentInChildren<TextMesh>().text = "["+_key.ToString()+"]";
        _text.gameObject.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            _isPlayerNearby = true;
            _text.gameObject.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            _isPlayerNearby = false;
            _text.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (_isPlayerNearby && Input.GetKeyDown(_key))
        {
            PerformAction();
        }
    }

    public abstract void PerformAction();
        

}
