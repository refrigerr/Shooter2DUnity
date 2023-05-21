using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class AmmunitionManager : MonoBehaviour
{
    private int[] _ammunitionStorage;
    //this variable exists only to pass sprites to _ammoSprites
    [SerializeField] private Sprite[] _toTransferAmmoSprites = new Sprite[Enum.GetNames(typeof(AmmunitionType)).Length];
    private static Sprite[] _ammoSprites;
    
    void Awake()
    {
        _ammunitionStorage = new int[Enum.GetNames(typeof(AmmunitionType)).Length];
        for(int i=0; i<_ammunitionStorage.Length;i++){
            _ammunitionStorage[i] = 11;
        }
        _ammoSprites = _toTransferAmmoSprites;
    }
    public void ChangeAmmoValue(int index, int amount)
    {
        _ammunitionStorage[index] += amount;
    }
    public int GetAmmoValue(int index)
    {
        return _ammunitionStorage[index];
    }

    public static Sprite GetAmmoSprite(int index)
    {
        return _ammoSprites[index];
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
