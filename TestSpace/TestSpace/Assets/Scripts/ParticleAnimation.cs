using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAnimation : MonoBehaviour {

    private float X;
    private float Y;
    private float Z;

    void Start() {
        X = Random.Range(-5f, 5f);
        Y = Random.Range(-5f, 5f);
        Z = Random.Range(-5f, 5f);
        StartCoroutine(Rotation());
    }

    void Update() {
        this.gameObject.GetComponent<Transform>().eulerAngles = this.gameObject.GetComponent<Transform>().eulerAngles + new Vector3 (X, Y, Z);
    }

    IEnumerator Rotation() {
        yield return new WaitForSeconds(1.5f);
        X = Random.Range(-5f, 5f);
        Y = Random.Range(-5f, 5f);
        Z = Random.Range(-5f, 5f);
        StartCoroutine(Rotation());
    }
}
