using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public string firstScene = "Level1"; // must match scene name exactly

    public void Play()
    {
        SceneManager.LoadScene(firstScene);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
