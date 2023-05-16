using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : ADamageableEntity
{

    [SerializeField] APickable[] _possibleEntitiesToDrop;
    protected override void DoOnDeath(){
        int random = Random.Range(0,_possibleEntitiesToDrop.Length-1);
        Instantiate(_possibleEntitiesToDrop[random],this.transform.position, Quaternion.identity);

    }
}
