using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonAudio : MonoBehaviour, ISelectHandler
{
	public AudioSource source; 

	// When highlighted with mouse.
	public void OnSelect (BaseEventData eventData)
	{
		source.Play();
	}
}