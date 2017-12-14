using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TUrnOnCat : MonoBehaviour 
{
	public GameObject catPaw1;
	public GameObject catPaw2;

	void OnTriggerEnter (Collider col)
	{
		if (col.transform.tag == "Player") 
		{
			catPaw1.SetActive (true);
			catPaw2.SetActive (true);
		}
	}

}
