using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfBreak : MonoBehaviour 
{
	public GameObject shelf;

	void OnTriggerEnter (Collider col)
	{
		if (col.transform.tag == "Player") 
		{
			shelf.SetActive (false);
		}
	}
}
