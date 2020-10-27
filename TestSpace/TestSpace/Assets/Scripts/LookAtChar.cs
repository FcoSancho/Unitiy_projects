using UnityEngine;
using Cinemachine;

public class LookAtChar : MonoBehaviour {
    
    public Transform camRig;
    public Transform charObj;
    public GameObject rotator;

    void Update() {
        camRig.position = new Vector3 (charObj.position.x, charObj.position.y, charObj.position.z);
        rotator.GetComponent<CinemachineFreeLook>().m_Orbits[2].m_Height = 0.35f + (0.5f - charObj.position.y);

        if (Input.GetMouseButton(0)) {
            rotator.GetComponent<CinemachineFreeLook>().m_XAxis.m_InputAxisValue = Input.GetAxis("Mouse X");
            rotator.GetComponent<CinemachineFreeLook>().m_YAxis.m_InputAxisValue = Input.GetAxis("Mouse Y");
        }
        if (!Input.GetMouseButton(0)) {
            rotator.GetComponent<CinemachineFreeLook>().m_XAxis.m_InputAxisValue = 0;
            rotator.GetComponent<CinemachineFreeLook>().m_YAxis.m_InputAxisValue = 0;
        }
    }
}
