using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public string firstScene = "Game"; 

    public void Play()
    {
        SceneManager.LoadScene(firstScene);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
