using UnityEngine;

public class LoseCheck : MonoBehaviour {

    public GameObject ballObj;
    public GameObject plateToLose;
    private void OnTriggerEnter(Collider collisonObj) {
        if (collisonObj.gameObject == ballObj) {
            plateToLose.GetComponent<AIPlate>().lose();
        }
    }
}
