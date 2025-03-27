using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void GoToGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
