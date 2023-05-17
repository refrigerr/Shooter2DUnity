using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UICoinDisplay : MonoBehaviour
{
    [SerializeField] private Text _currentCoinAmount;
    void Awake()
    {
        SetCoinAmount(GameObject.Find("Player").GetComponent<CoinManager>().GetCoinAmount());

    }

    public void SetCoinAmount(int amount){
        _currentCoinAmount.text = "x"+ amount;
    }
}
