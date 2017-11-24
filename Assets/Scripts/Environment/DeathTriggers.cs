using UnityEngine;

public class DeathTriggers : MonoBehaviour
{
    public GameObject deathMenu;

	public GameObject Death1;
	public GameObject Death2;
	public GameObject Death3;

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
				if (go.transform.parent != null) {
					go = go.transform.parent.gameObject;
				}
				else {
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

			if (lives <= 2)
			{
				Death1.SetActive(false);
			}

			if (lives <= 1)
			{
				Death2.SetActive(false);
			}

            if (lives <= 0)
            {
				Death3.SetActive(false);
                Time.timeScale = 0;
                deathMenu.SetActive(true);
            }
            else if (controller)
            {
				charcontroller.ReGround();
            }
        }
    }
}
