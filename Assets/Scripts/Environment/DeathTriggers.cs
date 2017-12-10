using UnityEngine;

public class DeathTriggers : MonoBehaviour
{
	GameObject script;
	UIScript UIscript;
	MainMenus mainMenu;

	public GameObject gnome;
	public GameObject teddy;
	public GameObject robot;
	public GameObject doll;

	CharController charControler;



	public void Start ()
	{
		mainMenu = FindObjectOfType<MainMenus> ();
	}

	public void Update()
	{
		script = GameObject.Find("LevelInterface");
		UIscript = script.GetComponent<UIScript>();
	}

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {

			print ("DeathTriggers.OnTriggerEnter - 0");

			Lives controller = col.GetComponent<Lives>();

			GameObject go = col.gameObject;
			CharController charcontroller;
			do {
				charcontroller = go.GetComponent<CharController>();
				if (go.transform.parent != null) 
				{
					go = go.transform.parent.gameObject;
				}
				else 
				{
					go = null;
				}
			} while (charcontroller == null && go != null);

			if (charcontroller.regrounding)
			{
				return;
			}

			print ("DeathTriggers.OnTriggerEnter - 1 controller = " + controller == null);
			print ("DeathTriggers.OnTriggerEnter - 1 charcontroller = " + charcontroller == null);

			if (!controller)
				controller = col.GetComponentInParent<Lives>();

			print ("DeathTriggers.OnTriggerEnter - 2 controller = " + controller == null);

			int lives = 0;
            if (controller)
                lives = controller.lives--;

			print ("DeathTriggers.OnTriggerEnter - 3 lives = " + lives);

//			if (mainMenu.respawning1 || mainMenu.respawning2 || mainMenu.respawning3)
//			{
//				UIscript.Death3.SetActive(true);
//				UIscript.Death2.SetActive(true);
//				UIscript.Death1.SetActive(true);
//			}
//

			if (lives <= 2)
			{
				UIscript.Death3.SetActive(true);
				UIscript.Death2.SetActive(true);
				UIscript.Death1.SetActive(true);
			}
			if (lives <= 1)
			{				
				UIscript.Death3.SetActive(true);
				UIscript.Death2.SetActive(true);
				UIscript.Death1.SetActive(false);
			}
            if (lives <= 0)
            {
				UIscript.Death3.SetActive(true);
				UIscript.Death2.SetActive(false);
				UIscript.Death1.SetActive(false);
            }
			if (lives <= -1 )
			{
				UIscript.Death3.SetActive(false);
				UIscript.Death2.SetActive(false);
				UIscript.Death1.SetActive(false);
				Time.timeScale = 0;
				UIscript.deathMenu.SetActive(true);
			}
            else if (controller)
            {
				charcontroller.ReGround();
            }
				

			if (col.name == "Gnome") 
			{
				gnome.GetComponent<CharController>().playerAudioSource.clip = gnome.GetComponent<CharController>().deathSounds [Random.Range (1, gnome.GetComponent<CharController>().deathSounds.Length)];  
				gnome.GetComponent<CharController>().playerAudioSource.Play (); 
			}
			if (col.name == "collider") 
			{
				teddy.GetComponent<CharController>().playerAudioSource.clip = teddy.GetComponent<CharController>().deathSounds [Random.Range (1, teddy.GetComponent<CharController>().deathSounds.Length)];  
				teddy.GetComponent<CharController>().playerAudioSource.Play (); 
			}
			if (col.name == "Doll") 
			{
				doll.GetComponent<CharController>().playerAudioSource.clip = doll.GetComponent<CharController>().deathSounds [Random.Range (1, doll.GetComponent<CharController>().deathSounds.Length)];  
				doll.GetComponent<CharController>().playerAudioSource.Play (); 
			}
			if (col.name == "Robot") 
			{
				robot.GetComponent<CharController>().playerAudioSource.clip = robot.GetComponent<CharController>().deathSounds [Random.Range (1, robot.GetComponent<CharController>().deathSounds.Length)];  
				robot.GetComponent<CharController>().playerAudioSource.Play (); 
			}

        }
    }
}
