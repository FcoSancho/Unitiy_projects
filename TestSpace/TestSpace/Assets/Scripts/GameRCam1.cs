using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
 
public class GameRCam1 : MonoBehaviour {

    public Transform camT;
    private float mouseX;
    private bool LookRight = false;
    private bool LookLeft = false;
    public RectTransform camButton;
    private bool camActive = false;
    private bool camStorage = false;
    private bool camWait = false;
    public Animator camANM;
    public Transform monRig;
    public GameObject ER;
    public GameObject EL;
    private bool CDown = true;
    // public MeshRenderer TestPlane;
    // public Texture TestText;

    IEnumerator camWaiting() {
        yield return new WaitForSeconds(0.25f);
        camWait = false;
    }

    IEnumerator camDownC() {
        yield return new WaitForSeconds(0.20f);
        CDown = true;
    }

    public void camActivate() {
        camStorage = camActive;
        if (camStorage == false && camWait == false) {
            camActive = true;
            camWait = true;
            StartCoroutine(camWaiting());
        }
        if (camStorage == true && camWait == false) {
            camActive = false;
            camWait = true;
            StartCoroutine(camWaiting());
        }
    }

    public void LY() {
        LookLeft = true;
    }
    public void LN() {
        LookLeft = false;
    }
    public void RY() {
        LookRight = true;
    }
    public void RN() {
        LookRight = false;
    }

    public void TurnLeft() {
        if (LookLeft == true && (camT.eulerAngles.y - (150 * Time.deltaTime)) >= 117) {
            camT.eulerAngles = camT.eulerAngles - (new Vector3 (0, 150, 0) * Time.deltaTime);
        }
    }

    public void TurnRight() {
        if (LookRight == true && (camT.eulerAngles.y + (150 * Time.deltaTime)) <= 243) {
            camT.eulerAngles = camT.eulerAngles + (new Vector3 (0, 150, 0) * Time.deltaTime);
        }
    }
 
    void Update() {
        monRig.position = camT.position;
        if (camActive == false) {
            monRig.eulerAngles = camT.eulerAngles;
        }
        if (camStorage == true && camActive == false) {
            monRig.eulerAngles = camT.eulerAngles - new Vector3 (0, 180, 0);
            StartCoroutine(camDownC());
            camANM.Play("camDownANM");
        }
        if (camStorage == false && camActive == true) {
            monRig.eulerAngles = camT.eulerAngles - new Vector3 (0, 180, 0);
            CDown = false;
            camANM.Play("camUpANM");
        }
        if (CDown == true) {
            ER.SetActive(true);
            EL.SetActive(true);
        }
        if (CDown == false) {
            ER.SetActive(false);
            EL.SetActive(false);
        }
        camButton.localPosition = Vector3.down * 155;
        TurnRight();
        TurnLeft();

        if (camT.eulerAngles.y < 117) {
            camT.eulerAngles = new Vector3 (0, 117, 0);
        }
        if (camT.eulerAngles.y > 243) {
            camT.eulerAngles = new Vector3 (0, 243, 0);
        }

        // TestPlane.material.mainTexture = TestText;
    }

    void LateUpdate() {
        if (camT.eulerAngles.y < 117) {
            camT.eulerAngles = new Vector3 (0, 117, 0);
        }
        if (camT.eulerAngles.y > 243) {
            camT.eulerAngles = new Vector3 (0, 243, 0);
        }
    }
}