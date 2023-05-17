using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : APickable
{

    protected override void OnPickUp(Collider2D collider2D)
    {
        collider2D.GetComponent<CoinManager>().ChangeCoinAmount(1);
    }
}
