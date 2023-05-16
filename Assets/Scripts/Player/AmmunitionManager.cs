using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AmmunitionManager : MonoBehaviour
{
    private int[] _ammunitionStorage;
    
    void Awake()
    {
        _ammunitionStorage = new int[Enum.GetNames(typeof(AmmunitionType)).Length];
        for(int i=0; i<_ammunitionStorage.Length;i++){
            _ammunitionStorage[i] = 11;
        }
    }
    public void ChangeAmmoValue(int index, int amount)
    {
        _ammunitionStorage[index] += amount;
    }
    public int GetAmmoValue(int index)
    {
        return _ammunitionStorage[index];
    }

    public enum AmmunitionType
    {
        PistolAmmo,
        LightAmmo,
        ShotgunAmmo,
        HeavyAmmo,
        ExplosiveAmmo,
        EnergyAmmo 
    }

}
