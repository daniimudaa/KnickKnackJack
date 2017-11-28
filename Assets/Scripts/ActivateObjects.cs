using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObjects : MonoBehaviour
{
	public GameObject obj;

	void OnTriggerEnter (Collider col)
	{
		if (col.transform.tag == "Player" && col.gameObject.name == "Robot")
		{
			obj.SetActive (true);
		}
	}
}
