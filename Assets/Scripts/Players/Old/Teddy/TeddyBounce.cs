using UnityEngine;

public class TeddyBounce : MonoBehaviour
{

    Animator anim;
    public GameObject forceJumpCol;
    public GameObject selfiepad;

    public bool forceJumping;
    public float bounceSpeed;

    private CharController controller;

    private void Awake()
    {
        controller = GetComponent<CharController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        ControlsManager.Controls controls = controller.controlsManager.GetControlsForCharacter(controller.characterIndex);

        if (controls == null)
            return;

        /*	
            To reference the animations set up in the animator for the character use - anim.SetBool ("isWalking", true); 
                OR 
            if a float reference then use anime.SetFloat ("teddyUp", 1); //Set the variable of the parameters (on left side of animator).

            DONT use this way - gameObject.GetComponent<Animator> ().Play ("TeddyGetup");

        */
        //selfbounce
        if (controls.GetButtonDown(controls.buttonAbility2))
        {
            anim.SetBool("teddyGettingup", false);
            anim.SetBool("teddyLay", false);

            //make a trigger zone intantiated before the actual jump pad to trigger a jump animation before adding force
            Instantiate(selfiepad, transform.position + (transform.forward * 7), transform.rotation);

            print("selfie");
            //anime.SetBool ("teddySelfie 0", true);  - put new animation here (teddy fluff)
            forceJumping = true;
        }

        if (controls.GetButtonDown(controls.buttonAbility1))
        {
            anim.SetBool("teddySelfie 0", false);

            bool gettingUp = anim.GetBool("teddyLay");

            anim.SetBool("teddyLay", !gettingUp);
            anim.SetBool("teddyGettingup", gettingUp);
            controller.movementEnabled = gettingUp;

            forceJumpCol.SetActive(!gettingUp);
            forceJumping = !gettingUp;
        }
    }
}
