using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AWindow : MonoBehaviour
{
    
    public static bool GameIsPaused = false;
    public GameObject windowUI;
    protected GameObject pauseSource = null;
    public void OpenWindow()
    {
        if(pauseSource != null)
            return;
        
        windowUI.SetActive(true);
        pauseSource = windowUI;
        Time.timeScale = 0f;
        GameIsPaused = true;
        
    }

    public void CloseWindow()
    {
        if(pauseSource != windowUI)
            return;

        windowUI.SetActive(false);
        pauseSource = null;
        Time.timeScale = 1f;
        GameIsPaused = false;
        
        
    }

}
