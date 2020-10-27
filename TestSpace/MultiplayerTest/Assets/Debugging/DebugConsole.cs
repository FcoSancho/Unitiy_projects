using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class DebugConsole : MonoBehaviour {

    private string input;
    public static DebugCommand PRINT;
    public List<object> commandList;
    private Keyboard kb {get{return InputSystem.GetDevice<Keyboard>();}}

    private void Update() {
        if (kb.enterKey.wasPressedThisFrame) {OnReturn();}
    }

    public void OnReturn() {
        HandleInput();
        input = "";
    }

    private void Awake() {
        PRINT = new DebugCommand("print", "", "", () => {Debug.Log("DEBUG!!!");});

        commandList = new List<object> {PRINT};
    }

    private void OnGUI() {
        float y = 0f;
        GUI.Box(new Rect(0, y, Screen.width, 30), "");
        GUI.backgroundColor = new Color(0, 0, 0, 0);
        input = GUI.TextField(new Rect(10f, y + 5f, Screen.width - 20f, 20f), input);
    }

    private void HandleInput() {
        for (int i = 0; i < commandList.Count; i++) {
            DebugCommandClass commandBase = commandList[i] as DebugCommandClass;

            if (input.Contains(commandBase.commandID)) {
                if (commandList[i] as DebugCommand != null) {
                    (commandList[i] as DebugCommand).Invoke();
                }
            }
        }
    }
}
