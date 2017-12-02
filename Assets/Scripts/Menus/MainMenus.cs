using UnityEngine;
using UnityEngine.SceneManagement;
using GamepadInput;

public class MainMenus : MonoBehaviour
{
	public CollectableManager.Level level;

	public GameObject pauseMenu;

	public bool controlScreen;

	public GameObject gnomeControlMenu;
	public GameObject teddyControlMenu;
	public GameObject robotControlMenu;
	public GameObject dollControlMenu;

	public GameObject turnoffUI_1;
	public GameObject turnoffUI_2;
	public GameObject turnoffUI_3;
	public GameObject turnoffUI_4;
	public GameObject turnoffUI_5;


    public void Start()
    {
        Time.timeScale = 1;

		controlScreen = false;
    }

	public void Update ()
	{
		BackButton ();
		ControlsMenuChange ();
	}

    public void Play()
    {
        SceneController.LoadScene("Scenes/Menus/PlayerConfiguration");
    }

    public void Controls()
    {
		turnoffUI_1.SetActive(false);
		turnoffUI_2.SetActive(false);
		turnoffUI_3.SetActive(false);
		turnoffUI_4.SetActive(false);
		turnoffUI_5.SetActive(false);

		controlScreen = true; 
		gnomeControlMenu.SetActive(true);
    }

	public void BackButton()
	{
		if (GamePad.GetButtonDown(GamePad.Button.B, GamePad.Index.Any)) 
		{
			
			gnomeControlMenu.SetActive (false);
			teddyControlMenu.SetActive (false);
			robotControlMenu.SetActive (false);
			dollControlMenu.SetActive (false);

			turnoffUI_1.SetActive(true);
			turnoffUI_2.SetActive(true);
			turnoffUI_3.SetActive(true);
			turnoffUI_4.SetActive(true);
			turnoffUI_5.SetActive(true);

			controlScreen = false;
		}
	}

	public void ControlsMenuChange()
	{
		if (controlScreen && GamePad.GetButtonDown (GamePad.Button.A, GamePad.Index.One)) 
		{
			gnomeControlMenu.SetActive (true);
			teddyControlMenu.SetActive (false);
			robotControlMenu.SetActive (false);
			dollControlMenu.SetActive (false);
		}

		if (controlScreen && GamePad.GetButtonDown (GamePad.Button.A, GamePad.Index.Two))  
		{
			gnomeControlMenu.SetActive (false);
			teddyControlMenu.SetActive (true);
			robotControlMenu.SetActive (false);
			dollControlMenu.SetActive (false); 
		}

		if (controlScreen && GamePad.GetButtonDown (GamePad.Button.A, GamePad.Index.Three))  
		{
			gnomeControlMenu.SetActive (false);
			teddyControlMenu.SetActive (false);
			robotControlMenu.SetActive (true);
			dollControlMenu.SetActive (false);
		}

		if (controlScreen && GamePad.GetButtonDown (GamePad.Button.A, GamePad.Index.Four))  
		{
			gnomeControlMenu.SetActive (false);
			teddyControlMenu.SetActive (false);
			robotControlMenu.SetActive (false);
			dollControlMenu.SetActive (true);
		}
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

	public void Credits()
	{
		SceneController.LoadScene("Credits");
	}
}
