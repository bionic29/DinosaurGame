using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject HiScorePanel,InstPanel;
    public static bool PanelOpened;

    private void Start()
    {
        PanelOpened = false;

    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void CheckHiScore()
    {
        PanelOpened = true;
        HiScorePanel.SetActive(true);
    }

    public void OpenOptions()
    {
        
    }

    public void CloseOptions()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
