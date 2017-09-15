using GamepadInput;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour 
{
	public GameObject pauseMenu;

	public GamePad.Button joinButton = GamePad.Button.Start;


	void Start () 
	{
		Time.timeScale = 1;
	}
	
	void Update () 
	{
		pauseMenuFunction ();
	}

	public void pauseMenuFunction()
	{


		//if pressed the start button
		if (GamePad.GetButtonDown(GamePad.Button.Start, GamePad.Index.Any))
		{
			pauseMenu.SetActive (true);
			Time.timeScale = 0;
		}
	}
}
