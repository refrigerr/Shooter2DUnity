using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : APickable
{
    [SerializeField] private float _duration;
    [SerializeField] private float _multiplier;
    protected override void OnPickUp(Collider2D collider2D)
    {
        StartCoroutine(BoostSpeed(collider2D));
    }

    IEnumerator BoostSpeed(Collider2D player)
    {
        player.GetComponent<PlayerMovement>().speed *= _multiplier;
        GetComponent<Collider2D>().enabled = false;
        GetComponentInChildren<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(_duration);
        player.GetComponent<PlayerMovement>().speed /= _multiplier;
        Destroy(this.gameObject);

    }
}
