using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAudio : MonoBehaviour 
{
	public AudioSource newaudio;
	public AudioSource beingplayed;

	void Start () 
	{
		StartCoroutine(StartAudio ());
	}

	IEnumerator StartAudio()
	{
		yield return new WaitForSeconds(37.5f);

		beingplayed.volume = 0f;

		yield return new WaitForSeconds(0.5f);

		newaudio.Play ();
		newaudio.volume = 0.05f;
		yield return new WaitForSeconds(1);
		newaudio.volume = 0.1f;
		yield return new WaitForSeconds(1);
		newaudio.volume = 0.2f;
		yield return new WaitForSeconds(1);
		newaudio.volume = 0.3f;
		yield return new WaitForSeconds(1);
		newaudio.volume = 0.4f;
		yield return new WaitForSeconds(1);
		newaudio.volume = 0.5f;

		yield return null;
	}

}
