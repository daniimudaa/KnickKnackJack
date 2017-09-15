using UnityEngine;

public class RotationController : MonoBehaviour 
{
	bool yRotation = false;

	public float pitchLeft = 10f;
	public float pitchRight = 30f;

	public float pitchLeftRate = 0.2f;
	public float pitchRightRate = 0.2f;

	void Update () 
	{
		if (yRotation) 
		{
			float currentVelocity = 0f;
			float newRotation = Mathf.SmoothDamp (transform.rotation.eulerAngles.x, pitchLeft, ref currentVelocity, pitchLeftRate);
			transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, newRotation));
		}
		else 
		{
			float currentVelocity = 0f;
			float newRotation = Mathf.SmoothDamp (transform.rotation.eulerAngles.x, pitchRight, ref currentVelocity, pitchRightRate);
			transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, newRotation));
		}
	}

	void SetPitchLow() 
	{
		yRotation = true;
	}

	void SetPitchHigh() 
	{
		yRotation = false;
	}
}
