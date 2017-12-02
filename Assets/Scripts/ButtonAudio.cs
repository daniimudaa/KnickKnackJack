using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAudio : MonoBehaviour, ISelectHandler
{
	public AudioSource source; 

	void Start ()
	{
		source = gameObject.GetComponent<AudioSource> ();
	}

	// When highlighted with mouse.
	public void OnSelect (BaseEventData eventData)
	{
		
		print ("Playing Sound");
		source.Play();
		print ("Played Sound");
	}
}