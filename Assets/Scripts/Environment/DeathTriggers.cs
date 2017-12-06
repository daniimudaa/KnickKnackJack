using UnityEngine;

public class DeathTriggers : MonoBehaviour
{
	GameObject script;
	UIScript UIscript;
	MainMenus mainMenu;

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
				
        }
    }
}
