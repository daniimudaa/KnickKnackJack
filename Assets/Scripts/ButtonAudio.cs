using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonAudio : MonoBehaviour
{
	public AudioSource source; 

	void Start ()
	{
		source = gameObject.GetComponent<AudioSource> ();
	}

	// When highlighted with mouse.
	public void OnPointerEnter (Collider col)
	{
		
		print ("Playing Sound");
		source.Play();
		print ("Played Sound");
	}
}