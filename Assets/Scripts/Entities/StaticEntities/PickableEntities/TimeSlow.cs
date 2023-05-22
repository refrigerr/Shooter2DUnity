using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSlow : APickable
{
    [SerializeField] private float _duration;
    [SerializeField] private float _multiplier;
    protected override void OnPickUp(Collider2D collider2D)
    {
        StartCoroutine(SlowTime(collider2D));
    }

    IEnumerator SlowTime(Collider2D player)
    {
        Time.timeScale *= _multiplier;

        GetComponent<Collider2D>().enabled = false;
        GetComponentInChildren<SpriteRenderer>().enabled = false;

        yield return new WaitForSeconds(_duration);

        Time.timeScale /= _multiplier;
        Debug.Log(Time.timeScale);

        Destroy(this.gameObject);

    }
}
