using System;
using UnityEngine;

public class CharController : MonoBehaviour
{
    public float speed = 10;
    public float faceSpeed = 30;

    public float variableForceUp = 50;
    public float variableForceDown;

    public float jumpLimit;

    public float deadzone = 0.2f;

    public float rayBuffer = .1F;

    //public int lives = 3;

    //[NonSerialized]
    public bool isGrounded = true;

    public float currentSpeed;

    public Character characterIndex;

    [NonSerialized]
    public bool movementEnabled = true;

    Animator anim;

    [NonSerialized]
    public ControlsManager controlsManager;

    public bool climbable2 = false;

    //Alex stuff
    public bool climbable = false;

    public new GameObject camera;

    private new Collider collider;

    public Vector3 lastGround;
	public bool regrounding;


	private MainMenus menuScript;
	private Lives livesScript;
	public Transform respawn1; 
	public Transform respawn2;
	public Transform respawn3;
	public bool entered1;
	public bool entered2;
	public bool entered3;
	public GameObject MenuScriptObj;

	public bool doJump = false;
	public bool isTeddyJump = false;
	public bool teddyJump = false;
	public float teddyJumpVelocity = 100f;
	public float teddyJumpGravity = 800f;

	public AudioSource teddyAudioSource;
	public AudioClip teddySqueak;
	public bool audioPlay;

	public AudioClip[] deathSounds;
	public AudioSource playerAudioSource;


    void Start()
    {
        collider = GetComponentInChildren<Collider>();

        camera = Camera.main.gameObject;

        isGrounded = false;
        anim = GetComponent<Animator>();

        controlsManager = GetComponentInParent<ControlsManager>(); // Get the controls manager from the parent

		entered1 = false;
		entered2 = false;
		entered3 = false;

		audioPlay = false;
    }

    void Update()
    {
		regrounding = false;

        if (!climbable || !climbable2)
        {
            CharacterControls();
        }

        UpdateAnimator();
    }

	void FixedUpdate()
	{
		CharacterJump();
	}

    public void CharacterControls()
    {
        // If movement is disabled, we reset the speed, and stop
        if (!movementEnabled)
        {
            currentSpeed = 0F;
            return;
        }

        // Get the current controls
        ControlsManager.Controls controls = controlsManager.GetControlsForCharacter(characterIndex);

        // If there is no controller assigned, stop, we don't control the movement at all
        if (controls == null)
            return;

		// Check if we need to jump.  We do the actual jumping in FixedUpdate
		doJump = controls.GetButtonDown (controls.buttonJump);

        // Reset current speed
        currentSpeed = 0F;

        // Initialize the left stick to zero
        Vector2 movementAxis = Vector2.zero;

        // Get the current movement axis
        movementAxis = controls.GetAxis(controls.movementAxis);

        // JOE'S TEST ON KEYBOARD - REFERENCE (DELETE LATER IF NECESSARY)...
        //if (characterIndex == 0)
        //    movementAxis = new Vector2(Input.GetKey(KeyCode.LeftArrow) ? -1f : Input.GetKey(KeyCode.RightArrow) ? 1f : 0f, Input.GetKey(KeyCode.DownArrow) ? -1f : Input.GetKey(KeyCode.UpArrow) ? 1f : 0f);

        #region ALTERED_MOVEMENT
        // JOE'S ALTERATION TO THE MOVEMENT TO MOVE IN LOCAL SPACE RELATIVE TO THE CAMERA.
        // Grab the camera right position for the players
        Vector3 cameraWorldRight = camera.transform.right;
        // Keep the Y position in place
        cameraWorldRight.y = 0f;
        // Normalize to keep the unit 1 length
        cameraWorldRight.Normalize();
        // Grab the camera's forward position for the players
        Vector3 cameraWorldForward = camera.transform.forward;
        // Keep the Y position in place
        cameraWorldForward.y = 0f;
        // Normalize to keep the unit 1 length
        cameraWorldForward.Normalize();

        // Now store those properties into the translation vector variable
        Vector3 translation = movementAxis.x * cameraWorldRight + movementAxis.y * cameraWorldForward;

        if (translation.magnitude > deadzone)
        {
            // Set the current speed for the animator
            currentSpeed = movementAxis.magnitude * speed;

            // Translation movement in world space

            gameObject.transform.Translate(translation * speed * Time.deltaTime, Space.World); // space.world movement to camera view movement needed in here

            float angle = -(Mathf.Rad2Deg * Mathf.Atan2(translation.z, translation.x) - 90f);
            Quaternion quat = Quaternion.Euler(new Vector3(0, angle, 0));

            // Rotation
            float step = translation.magnitude * faceSpeed;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, quat, step);
        }
        #endregion
    }

    void UpdateAnimator()
    {
        anim.SetFloat("speed", currentSpeed);
    }

    void CharacterJump()
    {
//        bool gnd = isGrounded;

		int layerMask = 1 << 8;  // The player is on layer 8

		// This would cast rays only against colliders in layer 8.
		// But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
		layerMask = ~layerMask;

		isGrounded = Physics.Raycast(new Ray(collider.bounds.center, Vector3.down), collider.bounds.extents.y + rayBuffer, layerMask, QueryTriggerInteraction.Ignore);

        if (isGrounded)
        {
            lastGround = transform.localPosition;
			isTeddyJump = false;

			audioPlay = false;

			anim.SetBool ("jump", false);

            // If the controls are available and the jump button is down
            if (doJump)
            {
				doJump = false;

				isGrounded = false;

				print("waiiting for jump");

				if (teddyJump) {
					isTeddyJump = true;
					audioPlay = true;

					gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.up * teddyJumpVelocity, ForceMode.VelocityChange);
				} else {
					gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.up * variableForceUp, ForceMode.Impulse);
				}
            }
        }
        else if (gameObject.GetComponent<Rigidbody>().useGravity)
        {
			if (isTeddyJump) 
			{
				gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.down * teddyJumpGravity, ForceMode.Force);
			} 

			else 
			{
				gameObject.GetComponent<Rigidbody> ().AddForce (Vector3.down * variableForceDown, ForceMode.Force);
			}

			anim.SetBool ("jump", true);

			if (audioPlay) 
			{
				teddyAudioSource.PlayOneShot (teddySqueak);
				audioPlay = false;
			}
        }
    }



    public void ReGround()
    {
		
		regrounding = true;
        transform.localPosition = lastGround;
    }

    public enum Character
    {
        GNOME = 0,
        TEDDY = 1,
        ROBOT = 2,
        DOLL = 3
    }

	public void Checkpoints()
	{
		menuScript = MenuScriptObj.GetComponent<MainMenus>();
		livesScript = FindObjectOfType<Lives> ();

        if (menuScript.respawning3) 
        {
			this.transform.position = respawn3.position; 
			livesScript.lives = 1;
			menuScript.deathMenu.SetActive (false);
			Time.timeScale = 1;
        }
        else if (menuScript.respawning2) 
        {
            this.transform.position = respawn2.position;
			menuScript.deathMenu.SetActive (false);
			livesScript.lives = 1;
			Time.timeScale = 1;
        }
		else if (menuScript.respawning1) 
		{
			this.transform.position = respawn1.position;
			livesScript.lives = 1;
			menuScript.deathMenu.SetActive (false);
			Time.timeScale = 1;
		}
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.transform.name == "Spawn1") 
		{
			entered1 = true;
			entered2 = false;
			entered3 = false;
		}

		if (col.gameObject.name == "Spawn2") 
		{
			entered1 = false;
			entered2 = true;
			entered3 = false;
		}

		if (col.gameObject.name == "Spawn3") 
		{
			entered1 = false;
			entered2 = false;
			entered3 = true;
		}
	}


}
