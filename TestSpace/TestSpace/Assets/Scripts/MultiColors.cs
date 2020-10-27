using UnityEngine;

public class MultiColors : MonoBehaviour {

    private float R = 0;
    private float G = 0;
    private float B = 0;
    public Material mat;

    void Update() {
        R += 0.1f;
        G += 0.3f;
        B += 0.5f;
        if (R > 255) {
            R -= 255;
        }
        if (G > 255) {
            G -= 255;
        }
        if (B > 255) {
            B -= 255;
        }
        if (R < 0) {
            R += 255;
        }
        if (G < 0) {
            G += 255;
        }
        if (B < 0) {
            B += 255;
        }
        mat.SetColor("_Color", new Color (R/255, G/255, B/255));
    }
}
