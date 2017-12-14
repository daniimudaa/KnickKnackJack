using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour 
{
	private CharController controller;
	public Animation anim;
	public Animation anim2;
	public Animation anim3;

	void OnTriggerEnter(Collider col)
	{

		if (col.gameObject.CompareTag("Player"))
		{
			CharController controller = col.gameObject.GetComponent<CharController>();

			if (col.gameObject.name == "collider")
			{
				print ("Playing Animation");
				this.anim.Play();
				Destroy (gameObject);
			}		
		}

		if (col.gameObject.name == "Doll") 
		{
			anim2.Play();
		}
	
	}


}
