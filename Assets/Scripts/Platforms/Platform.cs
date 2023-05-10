using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.CompareTag("Projectile"))
            return;

        collider2D.transform.SetParent(this.transform);
    }
    private void OnTriggerExit2D(Collider2D collider2D)
    {
        collider2D.transform.SetParent(null);
    }
}
