using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    public void Play() {
        SceneManager.LoadSceneAsync("World");
    }
}
