using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{

    private int _coinsAmount = 0;
    [SerializeField] private UICoinDisplay _UICoinDisplay;
    public void ChangeCoinAmount(int amount){
        _coinsAmount += amount;
        _UICoinDisplay.SetCoinAmount(_coinsAmount);
    }
    public int GetCoinAmount(){
        return _coinsAmount;
    }   
}
