using UnityEngine;
using UnityEngine.InputSystem;
using Mirror;

public class PlayerMove : NetworkBehaviour {

    private MainPlayerControls ctrls;
    private MainPlayerControls controls {get{
        if (ctrls != null) {return ctrls;}
        return ctrls = new MainPlayerControls();
        }}
    private Vector2 moveVec = Vector2.zero;
    private bool JStop = true;
    private Vector2 BVec = Vector2.zero;

    [Client]
    public override void OnStartAuthority() {
        enabled = true;
        controls.Player.MovementButtonsX.performed += ctx => parseBIn(ctx.ReadValue<float>(), "x");
        controls.Player.MovementButtonsY.performed += ctx => parseBIn(ctx.ReadValue<float>(), "y");
        controls.Player.MovementJoysticks.performed += ctx => parseJIn(ctx.ReadValue<Vector2>());
    }

    [Client]
    private void move(Vector2 direction, bool setOrGet, string controlID) {
        if (setOrGet) {
            if (controlID == "joystick") {moveVec = direction * Time.deltaTime * 15;}
            if (controlID == "button") {moveVec = direction * Time.deltaTime * 10;}
        } else if (!setOrGet) {this.gameObject.GetComponent<Transform>().position = this.gameObject.GetComponent<Transform>().position + new Vector3(moveVec.x, 0, moveVec.y);}
    }

    [Client]
    private void parseJIn(Vector2 check) {
        if (check != Vector2.zero) {CmdSetMove(check, true, "joystick"); JStop = false;}
        if (check == Vector2.zero && JStop == false) {CmdSetMove(Vector2.zero, true, "joystick"); JStop = true;}
    }

    [Client]
    private void parseBIn(float point, string XOrY) {
        if (XOrY == "x") {BVec.x = point;}
        if (XOrY == "y") {BVec.y = point;}
        if (BVec.sqrMagnitude > 1) {BVec = BVec.normalized;}
        CmdSetMove(BVec, true, "button");
    }

    [ClientCallback]
    private void Update() {
        if (!hasAuthority) {return;}
        CmdMove();
    }

    [Command]
    private void CmdMove() {
        move(Vector2.zero, false, "");
    }

    [Command]
    private void CmdSetMove(Vector2 direction, bool setOrGet, string controlID) {
        move(direction, setOrGet, controlID);
    }

    [ClientCallback]
    private void OnEnable() {
        controls.Enable();
    }

    [ClientCallback]
    private void OnDisable() {
        controls.Disable();
    }
}