using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Gun", menuName ="Weapon/Gun")]
public class GunData : ScriptableObject
{
    [Header("Info")]
    public new string name;
    [Header("Shooting")]
    public int damage;
    public int ammoPerShot;
    public GameObject projectile;
    public float projectileSpeed;
    public float projectileAliveInSeconds;
    public AmmunitionManager.AmmunitionType ammoType;
 
    [Header("Reloading")]
    public int currentAmmo;
    public int magSize;
    public float fireRate;
    public float reloadTime;
    [HideInInspector]
    public bool reloading;
 
}
