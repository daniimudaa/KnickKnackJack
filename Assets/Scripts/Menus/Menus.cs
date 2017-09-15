using UnityEngine;

public class Menus : MonoBehaviour
{



    //	// Use this for initialization
    //	void Start () {
    //		
    //	}
    //	
    //	// Update is called once per frame
    //	void Update () {
    //		
    //	}

    public void NewGameBtn(string Puzzle1)
    {
        SceneController.LoadScene(Puzzle1);
    }

    public void ExitGameBtn()
    {
        Application.Quit();
    }
    public void InstructionBtn(string InstructionScene)
    {
        SceneController.LoadScene(InstructionScene);

    }
}
