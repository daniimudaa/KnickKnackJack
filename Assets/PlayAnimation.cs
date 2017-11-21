using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimation : MonoBehaviour 
{
	private CharController controller;
	public Animation anim;

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.CompareTag("Player"))
		{
			CharController controller = col.gameObject.GetComponent<CharController>();
			print ("Teddy Recognised");

			if (controller.characterIndex == CharController.Character.TEDDY)
			{
				print ("Playing Animation");
				anim.Play();
			}		
		}
	}
}
