using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    
    public GameObject PauseWindow, PauseButton, MenuUI;

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Pause()
    {
        PauseWindow.SetActive(true);
        PauseButton.SetActive(false);
        MenuUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        PauseWindow.SetActive(false);
        PauseButton.SetActive(true);
        MenuUI.SetActive(true);
        Time.timeScale = 1;
    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

  
     
    public void Exit()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.LoadLevel(0);
    }

    
}
