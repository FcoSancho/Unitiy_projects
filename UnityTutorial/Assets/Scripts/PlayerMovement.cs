using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;

    // Start is called before the first frame update
   /* void Start() {
        rb.AddForce(0, 200, 500);
    }*/

    // Update is called once per frame
   /* void Update() {
        rb.AddForce(0, 0, 2000 * Time.deltaTime);
    }*/

    // It's marked as "Fixed"Update because physics are being used
     void FixedUpdate() {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow)) {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow)) {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

       /*if (Input.GetKey("space")) {
            rb.AddForce(0, 50 * Time.deltaTime, 0);
        }*/

        if (rb.position.y < -1f) {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
