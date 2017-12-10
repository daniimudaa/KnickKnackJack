using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAudio : MonoBehaviour
{
	public AudioSource source;
	public AudioClip[] clips;

	public void OnTriggerEnter (Collider col)
	{
		if (col.transform.tag == "Player") 
		{
			source.clip = clips [Random.Range (1, clips.Length)];  
			source.Play ();
		}
	}
}
