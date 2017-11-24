using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenus : MonoBehaviour
{
	public CollectableManager.Level level;

	public GameObject pauseMenu;

    public void Start()
    {
        Time.timeScale = 1;
    }

    public void Play()
    {
        SceneController.LoadScene("Scenes/Menus/PlayerConfiguration");
    }

    public void Instructions()
    {
        SceneController.LoadScene("InstructionScene");
    }

    public void QuitGame()
    {
        Application.Quit();


#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void Reload()
    {
		CollectableManager.GetCollectable (level).Clear ();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    public void QuitToMainMenu()
    {
        SceneController.LoadScene("MainMenu");
    }
}
