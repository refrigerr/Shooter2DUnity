using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuWindow : AWindow
{
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                CloseWindow();
            }
            else
            {
                OpenWindow();
            }
        }
    }

    public void ResumeGame()
    {
        if(GameIsPaused)
        {
            CloseWindow();
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
