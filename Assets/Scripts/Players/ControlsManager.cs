using GamepadInput;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ControlsManager : MonoBehaviour
{
    public int[] playerReassignments = { 0, 1, 2, 3 };

    [Tooltip("The current controls mode that the game is running under")]
    public ControlsMode controlsConfiguration = ControlsMode.FOUR;

    [Header("Controllers")]
    public Controls player1;
    public Controls player2;
    public Controls player3;
    public Controls player4;

    private int[] playerControls;
    private int[] unusedControls;

    private void Awake()
    {
        // If the character setup is configured
        if (CharacterSetup.isConfigured)
        {
            // Copy the controls configuration from it
            controlsConfiguration = CharacterSetup.numControllers;

            // Assign controllers based on it
            for (int i = 0; i < 4; i++)
            {
                if (CharacterSetup.controllerAssignments[i] != -1)
                    Map(i).gamepadIndex = CharacterSetup.controllerAssignments[i];
            }
        }

        // Create a complimentary pair of arrays
        playerControls = new int[(int)controlsConfiguration];
        unusedControls = new int[4 - (int)controlsConfiguration];

        // Initialize the first array
        for (int i = 0; i < playerControls.Length; i++)
        {
            playerControls[i] = i;
            Map(i).manager = this;
        }
        // Initialize the second array to contain all the elements the first array doesn't contain
        for (int i = 0; i < unusedControls.Length; i++)
            unusedControls[i] = i + (int)controlsConfiguration;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F3))
        {
            player1 = new PCControls();
            player1.gamepadIndex = 1;
        }

        // If there are players to switch with
        if (unusedControls.Length > 0)
            for (int i = 0; i < playerControls.Length; i++)
            {
                Controls c = Map(i);

                // If the character switch key was pressed
                if (c.GetButtonDown(c.buttonCharacterSwitch))
                {
                    Swap(i);
                }
            }
    }

    // Gets the controls for the specified character index, if any, otherwise returns null
    public Controls GetControlsForCharacter(int character)
    {
        for (int i = 0; i < playerControls.Length; i++)
            if (playerControls[i] == character)
                return Map(i);

        return null;
    }

    // Calls GetControlsForCharacter(int), casting the Character parameter to int
    public Controls GetControlsForCharacter(CharController.Character character)
    {
        return GetControlsForCharacter((int)character);
    }

    // Player number to controls map
    private Controls Map(int player)
    {
        switch (playerReassignments[player])
        {
            case 0:
                return player1;
            case 1:
                return player2;
            case 2:
                return player3;
            case 3:
                return player4;
            default:
                return null;
        }
    }

    // Swaps the player at index with the first element of the unused controls
    private void Swap(int control)
    {
        // If there are no controls to swap with, exit
        if (unusedControls.Length == 0)
            return;

        int oldControl = playerControls[control];
        int newControl = unusedControls[0];

        // Shift all elements of unusedControls to the left by one
        for (int i = 1; i < unusedControls.Length; i++)
            unusedControls[i - 1] = unusedControls[i];

        // Push the old control to the back of unused controls
        unusedControls[unusedControls.Length - 1] = oldControl;

        // Update the specified player control
        playerControls[control] = newControl;
    }

    [Serializable]
    public class Controls
    {
        [NonSerialized]
        public ControlsManager manager;

        [Header("Gamepad")]
        public int gamepadIndex;

        [Header("Controls")]
        public GamePad.Axis movementAxis = GamePad.Axis.LeftStick;

        [Space]
        public GamePad.Button buttonJump = GamePad.Button.A;
        public GamePad.Button buttonPlayerInteract = GamePad.Button.B;
        public GamePad.Button buttonObjInteract = GamePad.Button.X;
        public GamePad.Button buttonCharacterSwitch = GamePad.Button.Y;

        [Space]
        public GamePad.Button buttonAbility1 = GamePad.Button.RightShoulder;
        public GamePad.Button buttonAbility2 = GamePad.Button.LeftShoulder;

        [Space]
        public GamePad.Button buttonPause = GamePad.Button.Start;
        public GamePad.Button buttonMap = GamePad.Button.Back;

        // Gets the current state of the gamepad
        public GamepadState GetStateForGamepad()
        {
            return GamePad.GetState(GetIndexForGamepad());
        }

        // Gets the index enum value for the current gamepad
        public GamePad.Index GetIndexForGamepad()
        {
            return GetIndexForGamepad(gamepadIndex);
        }

        // Gets whether the specified button was pushed in this tick
        public virtual bool GetButtonDown(GamePad.Button button)
        {
            return GamePad.GetButtonDown(button, GetIndexForGamepad());
        }

        // Gets whether the specified button was released in this tick
        public virtual bool GetButtonUp(GamePad.Button button)
        {
            return GamePad.GetButtonUp(button, GetIndexForGamepad());
        }

        // Gets wheter the specified button is down
        public virtual bool GetButton(GamePad.Button button)
        {
            return GamePad.GetButton(button, GetIndexForGamepad());
        }

        // Gets the 2D value of the specified axis
        public virtual Vector2 GetAxis(GamePad.Axis axis)
        {
            return GamePad.GetAxis(axis, GetIndexForGamepad());
        }

        // Gets the index enum value of the specified gamepad id
        public static GamePad.Index GetIndexForGamepad(int gamepad)
        {
            // If the gamepad is out of range, return the default index
            if (gamepad < 1 || gamepad > 4)
                return default(GamePad.Index);

            // Otherwise return the gamepad of the specified ID
            return (GamePad.Index)gamepad;
        }
    }

    // An enum specifying how many controllers we should make do with
    public enum ControlsMode
    {
        ONE = 1,
        TWO = 2,
        THREE = 3,
        FOUR = 4
    }

    public class PCControls : Controls
    {
        private Dictionary<GamePad.Button, KeyCode> buttonKeyMap = new Dictionary<GamePad.Button, KeyCode>{
            { GamePad.Button.A, KeyCode.Space },
            { GamePad.Button.B, KeyCode.Q },
            { GamePad.Button.X, KeyCode.E },
            { GamePad.Button.Y, KeyCode.F },
            { GamePad.Button.RightShoulder, KeyCode.Z },
            { GamePad.Button.LeftShoulder, KeyCode.X },
            { GamePad.Button.Start, KeyCode.Escape },
            { GamePad.Button.Back, KeyCode.Tab }
        };

        private Dictionary<GamePad.Axis, string> axisKeyMap = new Dictionary<GamePad.Axis, string>
        {
            { GamePad.Axis.LeftStick, "PC_axisMove#" }
        };

        public override bool GetButtonDown(GamePad.Button button)
        {
            return buttonKeyMap.ContainsKey(button) && Input.GetKeyDown(buttonKeyMap[button]);
        }

        public override bool GetButtonUp(GamePad.Button button)
        {
            return buttonKeyMap.ContainsKey(button) && Input.GetKeyUp(buttonKeyMap[button]);
        }

        public override bool GetButton(GamePad.Button button)
        {
            return buttonKeyMap.ContainsKey(button) && Input.GetKey(buttonKeyMap[button]);
        }

        public override Vector2 GetAxis(GamePad.Axis axis)
        {
            if (axisKeyMap.ContainsKey(axis))
                return new Vector2(Input.GetAxis(axisKeyMap[axis].Replace('#', 'X')), Input.GetAxis(axisKeyMap[axis].Replace('#', 'Y')));

            return Vector2.zero;
        }
    }
}
