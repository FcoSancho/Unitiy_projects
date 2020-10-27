using UnityEngine;
using System;

public class DebugCommandClass {

    private string _commandID;
    private string _commandDes;
    private string _commandForm;
    public string commandID {get{return _commandID;}}
    public string commandDes {get{return _commandDes;}}
    public string commandForm {get{return _commandForm;}}

    public DebugCommandClass(string id, string des, string form) {
        _commandID = id;
        _commandDes = des;
        _commandForm = form;
    }
}

public class DebugCommand : DebugCommandClass {

    private Action command;

    public DebugCommand(string id, string des, string form, Action command) : base (id, des, form) {
        this.command = command;
    }

    public void Invoke() {
        command.Invoke();
    }
}
