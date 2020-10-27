using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform camTrans;
    private float mouseX;
    private float mouseY;
    private Vector3 camF;
    private Vector3 camR;
    private Vector3 camU;
    static public bool car = false;
    public Transform carObj;
    private Vector3 offsetToCar = new Vector3 (0, 1, -3);
    private float followSpeed = 10;
    private float lookSpeed = 10;
    private bool pressed = false;
    private float sensitivity = 500f;
    public Transform playerBody;
    private float xRotation = 0;



    void FixedUpdate() {
        if (Input.GetKey("c") && car == false && pressed == false) {
            car = true;
            pressed = true;
        } else if (!Input.GetKey("c")) {
            pressed = false;
        }
        if (Input.GetKey("c") && car == true && pressed == false) {
            car = false;
            pressed = true;
        } else if (!Input.GetKey("c")) {
            pressed = false;
        }
        if (car == false) {
            Walk();
            LookAround();
        }
        if (car == true) {
            carMovement();
            carLook();
        }
    }

    void LookAround() {
        if(Input.GetMouseButton(0)) {
            float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            this.gameObject.GetComponent<Transform>().localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);

            this.gameObject.GetComponent<Transform>().eulerAngles = new Vector3 (this.gameObject.GetComponent<Transform>().eulerAngles.x, playerBody.eulerAngles.y, this.gameObject.GetComponent<Transform>().eulerAngles.z);
        }
    }

    void Walk() {
        camF = camTrans.forward;
        camF.y = 0;
        camF = camF.normalized;
        camR = camTrans.right;
        camR.y = 0;
        camR = camR.normalized;
        camU = camTrans.up;
        camU.x = 0;
        camU.z = 0;
        camU = camU.normalized;
         if (Input.GetKey("space")) {
             camTrans.position = camTrans.position + (camU * Time.deltaTime * 1);
         }
         if (Input.GetKey("space") && Input.GetKey("left ctrl")) {
             camTrans.position = camTrans.position + (camU * Time.deltaTime * 10);
         }
         if (Input.GetKey("space") && Input.GetKey("right ctrl")) {
             camTrans.position = camTrans.position + (camU * Time.deltaTime * 10);
         }

         if (Input.GetKey("right shift")) {
             camTrans.position = camTrans.position + (camU * Time.deltaTime * -1);
         }
         if (Input.GetKey("right shift") && Input.GetKey("left ctrl")) {
             camTrans.position = camTrans.position + (camU * Time.deltaTime * -10);
         }
         if (Input.GetKey("right shift") && Input.GetKey("right ctrl")) {
             camTrans.position = camTrans.position + (camU * Time.deltaTime * -10);
         }
         if (Input.GetKey("left shift")) {
             camTrans.position = camTrans.position + (camU * Time.deltaTime * -1);
         }
         if (Input.GetKey("left shift") && Input.GetKey("left ctrl")) {
             camTrans.position = camTrans.position + (camU * Time.deltaTime * -10);
         }
         if (Input.GetKey("left shift") && Input.GetKey("right ctrl")) {
             camTrans.position = camTrans.position + (camU * Time.deltaTime * -10);
         }

         if (Input.GetKey("up") || Input.GetKey("w")) {
             camTrans.position = camTrans.position + (camF * Time.deltaTime * 1);
         }
         if (Input.GetKey("up") && Input.GetKey("left ctrl")) {
             camTrans.position = camTrans.position + (camF * Time.deltaTime * 10);
         }
         if (Input.GetKey("w") && Input.GetKey("left ctrl")) {
             camTrans.position = camTrans.position + (camF * Time.deltaTime * 10);
         }
         if (Input.GetKey("up") && Input.GetKey("right ctrl")) {
             camTrans.position = camTrans.position + (camF * Time.deltaTime * 10);
         }
         if (Input.GetKey("w") && Input.GetKey("right ctrl")) {
             camTrans.position = camTrans.position + (camF * Time.deltaTime * 10);
         }

         if (Input.GetKey("down") || Input.GetKey("s")) {
             camTrans.position = camTrans.position + (camF * Time.deltaTime * -1);
         }
         if (Input.GetKey("down") && Input.GetKey("left ctrl")) {
             camTrans.position = camTrans.position + (camF * Time.deltaTime * -10);
         }
         if (Input.GetKey("s") && Input.GetKey("left ctrl")) {
             camTrans.position = camTrans.position + (camF * Time.deltaTime * -10);
         }
         if (Input.GetKey("down") && Input.GetKey("right ctrl")) {
             camTrans.position = camTrans.position + (camF * Time.deltaTime * -10);
         }
         if (Input.GetKey("s") && Input.GetKey("right ctrl")) {
             camTrans.position = camTrans.position + (camF * Time.deltaTime * -10);
         }

         if (Input.GetKey("right") || Input.GetKey("d")) {
             camTrans.position = camTrans.position + (camR * Time.deltaTime * 1);
         }
         if (Input.GetKey("right") && Input.GetKey("left ctrl")) {
             camTrans.position = camTrans.position + (camR * Time.deltaTime * 10);
         }
         if (Input.GetKey("d") && Input.GetKey("left ctrl")) {
             camTrans.position = camTrans.position + (camR * Time.deltaTime * 10);
         }
         if (Input.GetKey("right") && Input.GetKey("right ctrl")) {
             camTrans.position = camTrans.position + (camR * Time.deltaTime * 10);
         }
         if (Input.GetKey("d") && Input.GetKey("right ctrl")) {
             camTrans.position = camTrans.position + (camR * Time.deltaTime * 10);
         }

         if (Input.GetKey("left") || Input.GetKey("a")) {
             camTrans.position = camTrans.position + (camR * Time.deltaTime * -1);
         }
         if (Input.GetKey("left") && Input.GetKey("left ctrl")) {
             camTrans.position = camTrans.position + (camR * Time.deltaTime * -10);
         }
         if (Input.GetKey("a") && Input.GetKey("left ctrl")) {
             camTrans.position = camTrans.position + (camR * Time.deltaTime * -10);
         }
         if (Input.GetKey("left") && Input.GetKey("right ctrl")) {
             camTrans.position = camTrans.position + (camR * Time.deltaTime * -10);
         }
         if (Input.GetKey("a") && Input.GetKey("right ctrl")) {
             camTrans.position = camTrans.position + (camR * Time.deltaTime * -10);
         }
    }

    void carMovement() {
        if (car == true && car != false) {
            Vector3 _targetPos = carObj.position + carObj.forward * offsetToCar.z + carObj.right * offsetToCar.x + carObj.up * offsetToCar.y;
            camTrans.position = Vector3.Lerp(camTrans.position, _targetPos, followSpeed * Time.deltaTime);
        }
    }
    void carLook() {
        if (car == true && car != false) {
            Vector3 _lookDirection = carObj.position - camTrans.position;
            Quaternion _rot = Quaternion.LookRotation(_lookDirection, Vector3.up);
            camTrans.rotation = Quaternion.Lerp(camTrans.rotation, _rot, lookSpeed * Time.deltaTime);
        }
    }
}
