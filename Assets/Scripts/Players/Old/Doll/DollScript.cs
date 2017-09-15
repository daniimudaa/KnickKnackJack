using UnityEngine;

// TODO: update if not obselete?
public class DollScript : MonoBehaviour
{
    public float speed = 10;

    public string xAxis4;
    public string yAxis4;

    public Animator anim;
    public bool IsWalkingOn;
    public bool movingTrig;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        CharacterControls();
        AnimationBools();
    }

    void CharacterControls()
    {
        movingTrig = false;

        if (Input.GetAxis(xAxis4) > 0.55f)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.right * speed);
            movingTrig = true;
        }

        if (Input.GetAxis(xAxis4) < -0.5f)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(-Vector3.right * speed);
            movingTrig = true;
        }
        //		print (Input.GetAxis(xAxis4));


        if (Input.GetAxis(yAxis4) > 0.55f)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back * speed);
            movingTrig = true;
        }

        if (Input.GetAxis(yAxis4) < -0.5f)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(-Vector3.back * speed);
            movingTrig = true;
        }
        //		print (Input.GetAxis(yAxis4));

        if (movingTrig == true)
        {
            IsWalkingOn = true;
        }
        if (movingTrig == false)
        {
            IsWalkingOn = false;
        }
    }

    void AnimationBools()
    {
        if (IsWalkingOn == true)
        {
            anim.SetBool("isWalking", true);
        }

        if (IsWalkingOn == false)
        {
            anim.SetBool("isWalking", false);
        }
    }
}
