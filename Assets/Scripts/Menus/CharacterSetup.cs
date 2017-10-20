using GamepadInput;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSetup : MonoBehaviour
{
    public static bool isConfigured = false;
    public static ControlsManager.ControlsMode numControllers;
    public static int[] controllerAssignments;

    public GamePad.Button startButton = GamePad.Button.A;
    public GamePad.Button joinButton = GamePad.Button.Start;
    public GamePad.Button leaveButton = GamePad.Button.B;

    public GameObject[] starts = new GameObject[4];
    public GameObject button;

    public Sprite[] controllerNumbers = new Sprite[5];

    private GameObject[] startTexts;
    private GameObject[] leaveButtons;
    private Image[] controllerIndicators;
    private int[] controllerOrder;

    private void Awake()
    {
        button.SetActive(false);

        startTexts = new GameObject[starts.Length];
        leaveButtons = new GameObject[starts.Length];
        controllerIndicators = new Image[starts.Length];
        controllerOrder = new int[starts.Length];

        for (int i = 0; i < starts.Length; i++)
        {
            startTexts[i] = starts[i].transform.Find("textPressStart").gameObject;
            startTexts[i].SetActive(i == 0);

            leaveButtons[i] = starts[i].transform.Find("spriteLeaveButton").gameObject;
            leaveButtons[i].SetActive(false);

            controllerIndicators[i] = starts[i].transform.Find("spriteControllerImage").GetComponent<Image>();
            controllerOrder[i] = -1;
        }
    }

    private void Update()
    {
        for (int i = 1; i < starts.Length + 1; i++)
        {
            GamePad.Index controllerIndex = ControlsManager.Controls.GetIndexForGamepad(i);

            if (controllerOrder.Contains(i))
            {
                if (GamePad.GetButtonDown(leaveButton, controllerIndex) || Input.GetKeyDown((KeyCode)((int)KeyCode.Alpha0 + (int)controllerIndex)))
                {
                    int ix = Array.FindIndex(controllerOrder, m => m == i);

                    controllerOrder[ix] = -1;
                    for (int j = ix + 1; j < controllerOrder.Length; j++)
                    {
                        controllerOrder[j - 1] = controllerOrder[j];
                        controllerIndicators[j - 1].sprite = controllerIndicators[j].sprite;
                        controllerOrder[j] = -1;
                        controllerIndicators[j - 1].sprite = controllerNumbers[0];
                    }

                    controllerIndicators[ix].sprite = controllerNumbers[0];
                    leaveButtons[ix].SetActive(false);

                    bool isSet = false;
                    for (int s = 0; s < startTexts.Length; s++)
                    {
                        startTexts[s].SetActive(!isSet && controllerOrder[s] == -1);
                        if (controllerOrder[s] == -1)
                            isSet = true;
                    }
                }

                continue;
            }

            if (GamePad.GetButtonDown(joinButton, controllerIndex) || Input.GetKeyDown((KeyCode)((int)KeyCode.Keypad0 + (int)controllerIndex)))
            {
                for (int c = 0; c < controllerOrder.Length; c++)
                    if (controllerOrder[c] == -1)
                    {
                        button.SetActive(true);

                        controllerOrder[c] = i;
                        controllerIndicators[c].sprite = controllerNumbers[i];
                        startTexts[c].SetActive(false);
                        leaveButtons[c].SetActive(true);

                        if (c + 1 < startTexts.Length)
                            startTexts[c + 1].SetActive(true);

                        return;
                    }
            }
        }

        if (controllerOrder[0] != -1 && GamePad.GetButton(startButton, ControlsManager.Controls.GetIndexForGamepad(controllerOrder[0])))
        {
            StartGame();
        }
    }

    private void StartGame()
    {
        isConfigured = true;

        int controllers = 0;
        foreach (int c in controllerOrder)
            if (c != -1)
                controllers++;

        numControllers = (ControlsManager.ControlsMode)controllers;
        controllerAssignments = controllerOrder;

        // SceneController.LoadScene("Scenes/TestScenes/Playground - Prototype - 1");

        //just testing my kitchen scene - dani
        SceneController.LoadScene("1.Intro");
    }

    private void OnValidate()
    {
        if (starts.Length != 4)
        {
            Debug.LogWarning("There must be 4 character starts specified");
            GameObject[] startsNew = new GameObject[4];

            for (int i = 0; i < startsNew.Length && i < starts.Length; i++)
                startsNew[i] = starts[i];

            starts = startsNew;
        }

        if (controllerNumbers.Length != 5)
        {
            Debug.LogWarning("There must be 5 controller number sprites specified");
            Sprite[] numbersNew = new Sprite[5];

            for (int i = 0; i < numbersNew.Length && i < controllerNumbers.Length; i++)
                numbersNew[i] = controllerNumbers[i];

            controllerNumbers = numbersNew;
        }
    }
}
