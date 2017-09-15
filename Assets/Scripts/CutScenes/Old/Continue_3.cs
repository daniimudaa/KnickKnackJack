using UnityEngine;

public class Continue_3 : MonoBehaviour
{

    void Start()
    {

    }


    void Update()
    {
        //i think i did this wrong here, its ment to be if any controller active presses A then it skips the scene and opens up the next

        if (Input.GetKey(KeyCode.JoystickButton0))
        {
            SceneController.LoadScene("Level03_Kitchen");
        }
    }
}

