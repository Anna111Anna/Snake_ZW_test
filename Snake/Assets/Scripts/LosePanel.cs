using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LosePanel : MonoBehaviour
{
    public void OnExitBtn()
    {
        SceneManager.LoadScene("MainMenu_Scene");
    }
    public void OnRestartBtn()
    {
        SceneManager.LoadScene("Game_Scene");
    }
}
