using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupboardFadeout : MonoBehaviour
{
	public Material[] materials;

	public float alpha = 1f;

	public bool fadingOut = false;
	public float duration = 2f;

	float startTime;

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("MainCamera")) {
			startTime = Time.time;
			fadingOut = true;
			startTime = Time.time - (1f - alpha) * duration;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("MainCamera")) {
			startTime = Time.time;
			fadingOut = false;
			startTime = Time.time - alpha * duration;
		}
	}

	void Start()
	{
		startTime = -duration;
	}

	void Update()
	{
//		if (Input.GetKeyDown (KeyCode.Space)) {
//			fadingOut = !fadingOut;
//
//			if (fadingOut) {
//				startTime = Time.time - (1f - alpha) * duration;
//			} else {
//				startTime = Time.time - alpha * duration;
//			}
//		}

		float t = (Time.time - startTime) / duration;

		if (fadingOut) {
			alpha = Mathf.Lerp (1f, 0f, t);
		} else {
			alpha = Mathf.Lerp (0f, 1f, t);
		}

		foreach (Material m in materials) {
			Color c = m.color;
			c.a = alpha;
			m.color = c;
		}
	}
}
