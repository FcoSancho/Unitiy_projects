using UnityEngine;

public class BallMove : MonoBehaviour {

    public GameObject plate;

    private void OnCollisionEnter(Collision colObj) {
        if (colObj.gameObject == plate) {
            plate.GetComponent<AIPlate>().UReward();
            this.gameObject.GetComponent<Rigidbody>().AddForce(Random.Range(0f, 500f), Random.Range(500f, 1000f), Random.Range(0f, 500f));
        }
    }
}
