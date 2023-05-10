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
        setHealth(GameObject.Find("Player").GetComponent<PlayerHealthManager>().getHealth());

    }

    public void setHealth(int health){
        _currentHP.text = "x"+ health;
    }
}
