using UnityEngine;

public class Continue_4 : MonoBehaviour
{

    void Start()
    {

    }


    void Update()
    {
        //i think i did this wrong here, its ment to be if any controller active presses A then it skips the scene and opens up the next

        if (Input.GetKey(KeyCode.JoystickButton0))
        {
            SceneController.LoadScene("4.EndingScene");
        }

        //also if collected all collectables over the levels then play 
        // SceneController.LoadScene("5.AlternativeEnding");

    }
}

