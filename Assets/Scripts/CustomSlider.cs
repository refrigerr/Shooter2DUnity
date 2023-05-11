using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CustomSlider : MonoBehaviour
{
    
    [SerializeField] private Vector3 _offset;
    private Slider _slider;
    private Transform _target;
    

    void Awake(){
        _target = this.transform.parent.transform.parent;
        _slider = this.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
        this.transform.rotation = Quaternion.identity;
        this.transform.position = _target.position + _offset;
        
        
    }
    public void UpdateHealthBar(float currentValue, float maxValue){
        _slider.value = currentValue / maxValue;

    }
}
