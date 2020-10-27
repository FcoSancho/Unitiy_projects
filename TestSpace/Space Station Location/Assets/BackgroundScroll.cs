using UnityEngine;

public class BackgroundScroll : MonoBehaviour {

    public Material backQuadText;
    private Vector2 mult;
    public Transform backQuadTrans;

    private void Start() {
        mult.x = Random.Range(-1.0f, 1.0f);
        mult.y = Random.Range(-1.0f, 1.0f);
    }

    private void Update() {
        backQuadText.mainTextureOffset = backQuadText.mainTextureOffset + (new Vector2(Time.deltaTime / 1000, Time.deltaTime / 1000) * mult);
        backQuadTrans.localScale = new Vector3(((Camera.main.orthographicSize * 2) * Screen.width / Screen.height) * 2.567f, (10 / (Camera.main.orthographicSize * 2)) * (Camera.main.orthographicSize * 2), 1);
        backQuadText.mainTextureScale = new Vector2(((float) 2 / (float) 10) * (((Camera.main.orthographicSize * 2) * Screen.width / Screen.height) * 2.567f), ((float) 2 / (float) 10) * ((10 / (Camera.main.orthographicSize * 2)) * (Camera.main.orthographicSize * 2)));
    }
}
