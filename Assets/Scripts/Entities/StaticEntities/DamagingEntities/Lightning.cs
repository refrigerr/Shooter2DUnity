using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private float _alpha;
    // Start is called before the first frame update
    void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }
    void Start (){
        _alpha = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //fading laser
        _alpha-=Time.deltaTime*2;
        Color color = new Color(1f,1f,1f,_alpha);
        _lineRenderer.startColor=color;
        _lineRenderer.endColor=color;

        if(_alpha<=0){
            Destroy(this.gameObject);
        }
  
        
    }
}
