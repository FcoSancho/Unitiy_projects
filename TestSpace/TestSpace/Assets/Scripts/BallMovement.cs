using UnityEngine;

public class BallMovement : MonoBehaviour {

    public Rigidbody rb;
    private bool keyIsPressed = false;

    void Start() {
        rb.AddForce(0, -1000, -10000 * Time.deltaTime);
    }

    void OnCollisionEnter() {
        rb.velocity *= 1.15f;
    }

    void FixedUpdate() {
        if (Input.GetKey("b") && keyIsPressed == false) {
            rb.AddForce(0, -1000, 0);
            keyIsPressed = true;
        }
        if (!Input.GetKey("b") && keyIsPressed == true) {
            keyIsPressed = false;
        }
    }
}
