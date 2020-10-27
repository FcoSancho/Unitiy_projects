using UnityEngine;
using Mirror;

public class SyncPosition : NetworkBehaviour {

    [Client]
    private void Update() {
        CmdSyncPos(this.gameObject.GetComponent<Transform>().position);
    }

    [Command]
    private void CmdSyncPos(Vector3 pos) {
        this.gameObject.GetComponent<Transform>().position = pos;
        SetDirtyBit(1u);
    }

    public override bool OnSerialize(NetworkWriter writer, bool initialState) {
        writer.WriteVector3(this.gameObject.GetComponent<Transform>().position);
        return true;
    }
    public override void OnDeserialize(NetworkReader reader, bool initialState) {
        if (hasAuthority) {return;}

        if ((reader.ReadVector3() - this.gameObject.GetComponent<Transform>().position).magnitude > 5f) {
            this.gameObject.GetComponent<Transform>().position = reader.ReadVector3();
        } else if ((reader.ReadVector3() - this.gameObject.GetComponent<Transform>().position).magnitude < 0.11f) {
            this.gameObject.GetComponent<Transform>().position = reader.ReadVector3();
        } else {
            this.gameObject.GetComponent<Transform>().position = Vector3.Lerp(this.gameObject.GetComponent<Transform>().position, reader.ReadVector3(), 5);
        }
    }
}
