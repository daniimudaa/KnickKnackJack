using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTraps : MonoBehaviour 
{
	public Animator mousetrapAnim;
	DeathTriggers deathscript;

	void Start ()
	{
		deathscript = gameObject.GetComponent<DeathTriggers>();

	}
		

	void OnTriggerEnter (Collider col)
	{
		if (col.transform.tag == "Trapped") 
		{
			//mousetrapAnim.Play();
			Destroy (gameObject.GetComponent<DeathTriggers> ());
		}

		if (col.transform.tag == "Player") 
		{
			//mousetrapAnim.Play();
		}

	}


}
