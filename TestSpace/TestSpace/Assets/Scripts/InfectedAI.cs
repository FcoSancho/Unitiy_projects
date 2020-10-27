using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class InfectedAI : MonoBehaviour {

    public Transform playerTrans;
    private Vector3 previousPos;
    public LayerMask NInfLay;
    private Collider[] targetL;
    private Collider target;
    private bool touchPlayer = false;
    private Collider playerColl;
    public GameObject gameOverUI;

    void Start() {
        previousPos = this.gameObject.GetComponent<Transform>().position;
    }
    
    void Update() {
        this.gameObject.GetComponent<NavMeshAgent>().speed = 1.5f;
        this.gameObject.GetComponent<NavMeshAgent>().SetDestination(playerTrans.position);

        if (previousPos != this.gameObject.GetComponent<Transform>().position) {
            this.gameObject.GetComponent<Animator>().Play("run");
            previousPos = this.gameObject.GetComponent<Transform>().position;
        } else if (previousPos == this.gameObject.GetComponent<Transform>().position) {
            this.gameObject.GetComponent<Animator>().Play("idle");
            previousPos = this.gameObject.GetComponent<Transform>().position;
        }

        Contact();
    }

    void Contact() {
        targetL = Physics.OverlapSphere(this.gameObject.GetComponent<Transform>().position, 1.25f, NInfLay);

        foreach(Collider touched in targetL) {
            if (touched.gameObject.name == "Player") {
                playerColl = touched;
                touchPlayer = true;
            }
        }

        if (targetL.Length <= 0) {
                target = null;
        }

        if (target == null) {
            if (targetL.Length > 0 && touchPlayer == false) {
                target = targetL[0];
            }
            if (touchPlayer == true) {
                target = playerColl;
            }
        }

        if (target != null) {
            if (touchPlayer == false) {
                target = targetL[0];
            }
            if (touchPlayer == true) {
                target = playerColl;
            }
        }

        if (touchPlayer == true) {
            gameOverUI.SetActive(true);
            playerColl.gameObject.GetComponent<SimpleCharacterControlFree>().enabled = false;
            if (playerColl.gameObject.GetComponent<Transform>().position.y <= 0.51f) {
                playerColl.gameObject.GetComponent<Animator>().Play("idle");
            }
        }

        touchPlayer = false;
    }
}
