using UnityEngine;

public class SimpleCarController : MonoBehaviour {

    private float m_HorInput;
    private float m_VerInput;
    private float m_steerAngle;

    public WheelCollider frontWRC, frontWLC;
    public WheelCollider backWRC, backWLC;

    public Transform frontWRT, frontWLT;
    public Transform backWRT, backWLT;

    private float maxSteerAngle = 45;
    private float motorForce = 1000;
    public Rigidbody rb;
    private int brakes;
    private bool jumped = false;

    public void GetInput() {
        m_HorInput = Input.GetAxis("Horizontal");
        m_VerInput = Input.GetAxis("Vertical");
    }

    private void Steer() {
        m_steerAngle = maxSteerAngle * m_HorInput;
        frontWLC.steerAngle = m_steerAngle;
        frontWRC.steerAngle = m_steerAngle;
    }

    private void Accelerate() {
        if (frontWLC.motorTorque > 0 && !Input.GetKey("w") && !Input.GetKey("up")) {
            brakes = 1000000;
            frontWLC.brakeTorque = brakes;
            backWLC.brakeTorque = brakes;
            frontWLC.motorTorque = -0.0001f;
            backWLC.motorTorque = -0.0001f;
        } else {
            brakes = 0;
            frontWLC.brakeTorque = brakes;
            backWLC.brakeTorque = brakes;
        }
        if (frontWRC.motorTorque > 0 && !Input.GetKey("w") && !Input.GetKey("up")) {
            brakes = 1000000;
            frontWRC.brakeTorque = brakes;
            backWRC.brakeTorque = brakes;
            frontWRC.motorTorque = -0.0001f;
            backWRC.motorTorque = -0.0001f;
        } else {
            brakes = 0;
            frontWRC.brakeTorque = brakes;
            backWRC.brakeTorque = brakes;
        }

        if (frontWLC.motorTorque < 0 && !Input.GetKey("s") && !Input.GetKey("down")) {
            brakes = 1000000;
            frontWLC.brakeTorque = brakes;
            backWLC.brakeTorque = brakes;
            frontWLC.motorTorque = 0;
            backWLC.motorTorque = 0;
        } else {
            brakes = 0;
            frontWLC.brakeTorque = brakes;
            backWLC.brakeTorque = brakes;
        }
        if (frontWRC.motorTorque < 0 && !Input.GetKey("s") && !Input.GetKey("down")) {
            brakes = 1000000;
            frontWRC.brakeTorque = brakes;
            backWRC.brakeTorque = brakes;
            frontWRC.motorTorque = 0;
            backWRC.motorTorque = 0;
        } else {
            brakes = 0;
            frontWRC.brakeTorque = brakes;
            backWRC.brakeTorque = brakes;
        }

        if (Input.GetKey("space") && jumped == false) {
            rb.AddForce(0, 1000000, 0);
            jumped = true;
        }
        if (!Input.GetKey("space") && jumped == true) {
            jumped = false;
        }

        frontWLC.motorTorque = m_VerInput * motorForce;
        frontWRC.motorTorque = m_VerInput * motorForce;
    }

    private void UpdateWheelPoses() {
        UpdateWheelPose(frontWLC, frontWLT);
        UpdateWheelPose(frontWRC, frontWRT);
        UpdateWheelPose(backWLC, backWLT);
        UpdateWheelPose(backWRC, backWRT);
    }

    private void UpdateWheelPose(WheelCollider _collider, Transform _transform) {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;
    }

    private void FixedUpdate() {
        if (CameraMovement.car == true) {
            GetInput();
            Steer();
            Accelerate();
            UpdateWheelPoses();
        }
    }
}
