using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairManager : MonoBehaviour
{
    [SerializeField] private Texture2D _crosshairTexture;
    private Vector2 _crosshairHotspot;
    // Start is called before the first frame update
    void Start()
    {
        _crosshairHotspot = new Vector2(_crosshairTexture.width/2, _crosshairTexture.height/2);
        Cursor.SetCursor(_crosshairTexture,_crosshairHotspot,CursorMode.Auto);
    }

   
}
