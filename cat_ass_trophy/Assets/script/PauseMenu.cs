using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject ui;

    //when "p" or "escape" is pressed, the game pauses
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            Toggle();
        }
    }

    //to toggle from pause to play when Pause Menu is open or close
    public void Toggle ()
    {
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            Time.timeScale = 0f;
        }else
        {
            Time.timeScale = 1f;
        }
    }
    //MenuScene is loaded 
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    //game pauses during Pause Menu
    public void PauseTime()
    {
        Time.timeScale = 0f;
    }

    //reload current scene 
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
