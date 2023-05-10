using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmunitionManager : MonoBehaviour
{
    [SerializeField] private int _howManyAmmoTypes;
    private int[] _ammunitionStorage;
    
    void Awake()
    {
        _ammunitionStorage = new int[_howManyAmmoTypes];
        for(int i=0; i<_ammunitionStorage.Length;i++){
            _ammunitionStorage[i] = 0;
        }
    }
    public void ChangeAmmoValue(int index, int amount)
    {
        _ammunitionStorage[index] += amount;
        Debug.Log(_ammunitionStorage[index]);
    }
    public int GetAmmoValue(int index)
    {
        return _ammunitionStorage[index];
    }

}
