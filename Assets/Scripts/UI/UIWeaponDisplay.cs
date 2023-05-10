using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIWeaponDisplay : MonoBehaviour
{
    [SerializeField] private Image _highLight;
    [SerializeField] private Image[] _weaponBoxes;
    [SerializeField] private float _howLongVisible;
    private CanvasGroup _canvasGroup;
    private float _visibleProgress;
    private bool _isVisible;

    void Awake()
    {
        _canvasGroup = this.GetComponent<CanvasGroup>();
       ChangeHighLightPosition(0);
    }
    void Update(){
        if(_isVisible){
            _visibleProgress += Time.deltaTime;
        }

        if(_visibleProgress>=_howLongVisible){
            
            _canvasGroup.alpha -= Time.deltaTime;
            if(_canvasGroup.alpha <= 0){
                _visibleProgress = 0;
                _isVisible = false;
            }

        }
    }
    
    public void ChangeHighLightPosition(int index){
        _highLight.rectTransform.position = _weaponBoxes[index].rectTransform.position;
        _canvasGroup.alpha = 1;
        _isVisible = true;
        _visibleProgress = 0;
    }

}
