using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnStartBtn()
    {
        SceneManager.LoadScene("Game_Scene");
    }

    public void OnExitBtn()
    {
        Application.Quit();
    }
}
