using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    //reload the scene
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //main menu is loaded
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}
