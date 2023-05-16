using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthDisplay : MonoBehaviour
{
    [SerializeField] private Text _currentHP;
    private PlayerHealthManager _playerHealthManager;
    void Awake()
    {
        SetHealth(GameObject.Find("Player").GetComponent<PlayerHealthManager>().getHealth());

    }

    public void SetHealth(int health){
        _currentHP.text = "x"+ health;
    }
}
