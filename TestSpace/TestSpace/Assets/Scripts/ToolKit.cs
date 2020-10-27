using UnityEngine;

public class ToolKit : MonoBehaviour {
    
    public GameObject flashlight;
    private bool flashlightB = false;
    private GameObject flashlightC;
    public GameObject throwingBall;
    private bool throwingBallB = false;
    private GameObject throwingBallC;

    void Update()
    {
        if (Input.GetMouseButton(2)) {
            if (flashlightB == false) {
                flashlightC = Instantiate(flashlight);
                flashlightC.GetComponent<Transform>().eulerAngles = this.GetComponent<Transform>().eulerAngles;
                flashlightC.GetComponent<Transform>().position = this.GetComponent<Transform>().position;
                flashlightB = true;
            }
            if (flashlightB == true) {
                flashlightC.GetComponent<Transform>().eulerAngles = this.GetComponent<Transform>().eulerAngles;
                flashlightC.GetComponent<Transform>().position = this.GetComponent<Transform>().position;
                flashlightB = true;
            }
        }

        if (!Input.GetMouseButton(2) && flashlightB == true) {
            Destroy(flashlightC);
            flashlightB = false;
        }


        if (Input.GetKey("l")) {
            if (throwingBallB == false) {
                throwingBallC = Instantiate(throwingBall);
                throwingBallC.GetComponent<Transform>().position = this.GetComponent<Transform>().position;
                throwingBallC.GetComponent<Rigidbody>().AddForce((this.GetComponent<Transform>().forward) * 1000);
                throwingBallB = true;
            }
            if (throwingBallB == true) {
                throwingBallB = true;
            }
        }

        if (!Input.GetKey("l") && throwingBallB == true) {
            Destroy(throwingBallC);
            throwingBallB = false;
        }
    }
}
