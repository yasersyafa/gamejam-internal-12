using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoTo: MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadTitleScreen()
    {
        SceneManager.LoadScene("TitleScreen"); // Ganti "HomeScreen" dengan nama scene Home Screen kamu
    }
    public void LoadMainScreen()
    {
        SceneManager.LoadScene("MainScene"); // Ganti "HomeScreen" dengan nama scene Home Screen kamu
    }
    public void QuitGame()
    {
        Application.Quit(); // Untuk menutup aplikasi game di build

    }
}
