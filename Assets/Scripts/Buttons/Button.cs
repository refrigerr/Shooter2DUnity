using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Button : MonoBehaviour
{
    private bool _isPlayerNearby = false;

    public void OnTriggerEnter2D(Collider2D collider2D)
        {
            if (collider2D.CompareTag("Player"))
            {
                _isPlayerNearby = true;
                this.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
 
        public void OnTriggerExit2D(Collider2D collider2D)
        {
            if (collider2D.CompareTag("Player"))
            {
                _isPlayerNearby = false;
                this.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
 
        private void Update()
        {
            if (_isPlayerNearby && Input.GetKeyDown(KeyCode.F))
            {
                PerformAction();
            }
        }
 
        public abstract void PerformAction();
        

}
