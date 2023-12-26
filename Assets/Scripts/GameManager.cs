using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{



   
    void Start()
    {
        
    }

  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }

    }

   public void PauseGame()
    {
        Time.timeScale = 0;
    }
   public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        
        Application.Quit();

    }





}
