using UnityEngine;

public class ThrowAxe : MonoBehaviour
{

    public GameObject pickAxe;

    private CharController controller;

    private void Awake()
    {
        controller = GetComponent<CharController>();
    }

    void Start()
    {
        pickAxe.SetActive(false);

    }

    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        ControlsManager.Controls controls = controller.controlsManager.GetControlsForCharacter(controller.characterIndex);

        print("kill me first");

        if (controls != null && other.transform.tag == "Player 1" && controls.GetButtonDown(controls.buttonPlayerInteract))
        {
            print("kill me");
            pickAxe.SetActive(true);
        }
    }
}
