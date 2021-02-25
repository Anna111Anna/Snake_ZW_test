using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LosePanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnExitBtn()
    {
        SceneManager.LoadScene("MainMenu_Scene");
    }
    public void OnRestartBtn()
    {
        SceneManager.LoadScene("Game_Scene");
    }
}
