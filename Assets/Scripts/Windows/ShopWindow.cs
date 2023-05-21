using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopWindow : AWindow
{
    [SerializeField] private CoinManager _coinManager;
    [SerializeField] private AmmunitionManager _ammunitionManager;
    [SerializeField] private PlayerHealthManager _playerHealthManager;
    [SerializeField] private TMPro.TMP_Text[] _ammunmitionAmountTexts;
    [SerializeField] private TMPro.TMP_Text _coinsAmountText;
    [SerializeField] private TMPro.TMP_Text _healthAmountText;
    [SerializeField] private Button[] _buyButtons;

    public override void OpenWindow()
    {
        if(pauseSource != null)
            return;
        
        windowUI.SetActive(true);
        pauseSource = windowUI;
        Time.timeScale = 0f;
        GameIsPaused = true;
        RefreshEverything();
        
    }

    //m_YourThirdButton.onClick.AddListener(() => ButtonClicked(42));
    void OnEnable()
    {
        _buyButtons[0].onClick.AddListener(() => BuyAmmo(0,30));
        _buyButtons[1].onClick.AddListener(() => BuyAmmo(1,60));
        _buyButtons[2].onClick.AddListener(() => BuyAmmo(2,24));
        _buyButtons[3].onClick.AddListener(() => BuyAmmo(3,15));
        _buyButtons[4].onClick.AddListener(() => BuyAmmo(4,10));
        _buyButtons[5].onClick.AddListener(() => BuyAmmo(5,15));
    }

    void OnDisable()
    {
        for(int i=0;i<_buyButtons.Length;i++){
            _buyButtons[i].onClick.RemoveAllListeners();
        }
    }

    
    private void RefreshEverything()
    {
        RefreshCoinsAMount();
        RefreshHealthAmount();
        for(int i=0;i<_ammunmitionAmountTexts.Length;i++){
            RefreshAmmoAmount(i);
        }

    }

    private void RefreshCoinsAMount()
    {
        _coinsAmountText.text = "x"+_coinManager.GetCoinAmount();
    }
    private void RefreshHealthAmount()
    {
        _healthAmountText.text = "x"+_playerHealthManager.GetHealth();
    }
    private void RefreshAmmoAmount(int index)
    {
        _ammunmitionAmountTexts[index].text = "x"+_ammunitionManager.GetAmmoValue(index);
    }

    private void BuyAmmo(int index, int amount)
    {
        if(_coinManager.GetCoinAmount()<1)
            return;
        
        _ammunitionManager.ChangeAmmoValue(index, amount);
        _coinManager.ChangeCoinAmount(-1);
        RefreshCoinsAMount();
        RefreshAmmoAmount(index);
    }
}
