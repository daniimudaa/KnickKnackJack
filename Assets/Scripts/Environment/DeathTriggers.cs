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
			Lives controller = col.GetComponent<Lives>();
			CharController charcontroller = col.GetComponent<CharController>();

            if (!controller)
				controller = col.GetComponentInParent<Lives>();

            int lives = 0;
            if (controller)
                lives = controller.lives--;

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
