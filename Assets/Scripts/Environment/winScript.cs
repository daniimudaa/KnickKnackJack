using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winScript : MonoBehaviour 
{

	public GameObject winScreen;


	public void OnTriggerStay (Collider col)
	{
		if (col.transform.tag == "Player") 
		{
			winScreen.SetActive (true);
		}
	}
}
