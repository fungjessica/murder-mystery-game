using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuControl : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    private bool paused = false;

    // Update is called once per frame
    private void Update()
    {
        if (UserInput.instance.pausePressed)
            TogglePause();
    }

    public void TogglePause() {
        paused = !paused;

        if (paused) {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        } else {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
    }

    public void MainMenu() {
        // Keybinds do not work if you return using this
        // SceneManager.LoadSceneAsync("Main Menu");
    }
}
