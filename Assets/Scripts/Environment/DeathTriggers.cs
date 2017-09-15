using UnityEngine;

public class DeathTriggers : MonoBehaviour
{
    public GameObject deathMenu;

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            CharController controller = col.GetComponent<CharController>();
            if (!controller)
                controller = col.GetComponentInParent<CharController>();

            int lives = 0;
            if (controller)
                lives = controller.lives--;

            if (lives <= 0)
            {
                Time.timeScale = 0;
                deathMenu.SetActive(true);
            }
            else if (controller)
            {
                controller.ReGround();
            }
        }

    }
}
