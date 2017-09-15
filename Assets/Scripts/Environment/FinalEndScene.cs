using UnityEngine;

public class FinalEndScene : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {

    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag == "Player")
        {
            //load the mp4 animatic ending scene - dumpster scene

            //SceneController.LoadScene("InstructionScene"); 
        }

    }
}
