using UnityEngine;

public class EarthRotation : MonoBehaviour {
    
    void Update() {
        this.gameObject.GetComponent<Transform>().eulerAngles = this.gameObject.GetComponent<Transform>().eulerAngles + new Vector3 (0, 5, 0);
    }
}
