using UnityEngine;

public class PitchController : MonoBehaviour
{

    public bool isPitchLow = false;

    public float pitchLow = 10f;
    public float pitchHigh = 30f;

    public float pitchLowRate = 0.2f;
    public float pitchHighRate = 0.2f;

    //my pitch testing
    public bool isPitchHigh = false;

    public bool isPitchExploring = true;
    public float pitchExploring = 60f;
    public float pitchExploringRate = 0.2f;

    public bool isPitchRotating = false;
    public float pitchRotating;
    public float pitchRotatingRate = 0.2f;

    void Update()
    {
        //Joe's Script
        //		if (isPitchLow) 
        //		{
        //			float currentVelocity = 0f;
        //			float newPitch = Mathf.SmoothDamp (transform.rotation.eulerAngles.x, pitchLow, ref currentVelocity, pitchLowRate);
        //			transform.rotation = Quaternion.Euler (new Vector3 (newPitch, 0f, 0f));
        //		}
        //		else 
        //		{
        //			float currentVelocity = 0f;
        //			float newPitch = Mathf.SmoothDamp (transform.rotation.eulerAngles.x, pitchHigh, ref currentVelocity, pitchHighRate);
        //			transform.rotation = Quaternion.Euler (new Vector3 (newPitch, 0f, 0f));
        //		}

        //my testing

        transform.eulerAngles = transform.eulerAngles.NormalizeRotation();
        if (isPitchLow)
        {
            float newPitch = Mathf.Lerp(transform.rotation.eulerAngles.x, pitchLow, pitchLowRate);
            transform.rotation = Quaternion.Euler(new Vector3(newPitch, 0f, 0f));
        }

        if (isPitchHigh)
        {
            float currentVelocity = 0f;
            float newPitch1 = Mathf.SmoothDamp(transform.rotation.eulerAngles.x, pitchHigh, ref currentVelocity, pitchHighRate);
            transform.rotation = Quaternion.Euler(new Vector3(newPitch1, 0f, 0f));
        }

        if (isPitchExploring)
        {
            float currentVelocity = 0f;
            float newPitch2 = Mathf.SmoothDamp(transform.rotation.eulerAngles.x, pitchExploring, ref currentVelocity, pitchExploringRate);
            transform.rotation = Quaternion.Euler(new Vector3(newPitch2, 0f, 0f));
        }

        if (isPitchRotating)
        {
            float currentVelocity = 0f;
            float newPitch3 = Mathf.SmoothDamp(transform.rotation.eulerAngles.y, pitchRotating, ref currentVelocity, pitchRotatingRate);
            // joes //transform.rotation = Quaternion.Euler (new Vector3 (pitchHigh, newPitch3, 0f));
            transform.rotation = Quaternion.Euler(new Vector3(pitchHigh, newPitch3, 0f));
            //isPitchRotating = false;
        }

    }

    void SetPitchLow()
    {
        isPitchLow = true;
        isPitchHigh = false;
        isPitchExploring = false;
    }

    void SetPitchHigh()
    {
        isPitchHigh = true;
        isPitchLow = false;
        isPitchExploring = false;

        //isPitchLow = false;
    }

    //mine
    void SetPitchExploring()
    {
        isPitchExploring = true;
        isPitchLow = false;
        isPitchHigh = false;
    }

    void SetPitchRotating()
    {
        isPitchLow = false;
        isPitchRotating = true;
    }

    void SetPitchRotatingStop()
    {
        isPitchRotating = false;
    }
}
