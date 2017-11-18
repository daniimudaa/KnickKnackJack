using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour 
{
	void OnTriggerEnter (Collider col) 
	{
		if (col.transform.tag == "Player") 
		{
			Time.timeScale = 0;
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
		}
	}
}
