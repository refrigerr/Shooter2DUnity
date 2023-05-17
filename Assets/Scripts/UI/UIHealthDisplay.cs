using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthDisplay : MonoBehaviour
{
    [SerializeField] private Text _currentHP;
    void Awake()
    {
        SetHealth(GameObject.Find("Player").GetComponent<PlayerHealthManager>().GetHealth());

    }

    public void SetHealth(int health){
        _currentHP.text = "x"+ health;
    }
}
