using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using System.Collections;
using System.Globalization;

public class GetCurrentLocation : MonoBehaviour {

    private readonly string baseURL = "http://api.open-notify.org/iss-now.json";
    private UnityWebRequest request;
    private JSONNode requestInfo;
    public Transform targetTransform;
    private float prevLat;
    private float prevLon;
    private bool firstFrame = true;
    private float prevTime;
    public Transform rotH;
    private float mouseX;
    private float mouseY;
    public Transform back;
    public Transform rotMH;

    private void Start() {
        StartCoroutine(GetRequest());
    }

    private IEnumerator GetRequest() {
        request = UnityWebRequest.Get(baseURL);
        prevTime = Time.time;
        yield return request.SendWebRequest();
        if (!request.isNetworkError && !request.isHttpError) {
            requestInfo = JSON.Parse(request.downloadHandler.text);
            if (firstFrame) {
                rotMH.localEulerAngles = new Vector3 (float.Parse(requestInfo["iss_position"]["latitude"], CultureInfo.InvariantCulture), float.Parse(requestInfo["iss_position"]["longitude"], CultureInfo.InvariantCulture) * -1, 0);
                rotH.eulerAngles = new Vector3 (0, 0, 0);
                rotMH.LookAt(back);
                prevLat = float.Parse(requestInfo["iss_position"]["latitude"], CultureInfo.InvariantCulture);
                prevLon = float.Parse(requestInfo["iss_position"]["longitude"], CultureInfo.InvariantCulture) * -1;
                firstFrame = false;
            }
            targetTransform.localEulerAngles = Vector3.Lerp(new Vector3 (prevLat, prevLon, 0), new Vector3 (float.Parse(requestInfo["iss_position"]["latitude"], CultureInfo.InvariantCulture), float.Parse(requestInfo["iss_position"]["longitude"], CultureInfo.InvariantCulture) * -1, 0), Time.time - prevTime);
            prevLat = float.Parse(requestInfo["iss_position"]["latitude"], CultureInfo.InvariantCulture);
            prevLon = float.Parse(requestInfo["iss_position"]["longitude"], CultureInfo.InvariantCulture) * -1;
        }
        StartCoroutine(GetRequest());
    }

    private void Update() {
        if (Input.GetMouseButton(0)) {
            mouseX = Input.GetAxis("Mouse X") * 375 * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * 375 * Time.deltaTime;
            rotH.Rotate(Vector3.up * -mouseX, Space.World);
            rotH.Rotate(Vector3.right * mouseY, Space.World);
        }
        if (Input.GetKey("q")) {
            rotH.Rotate(Vector3.forward * 150 * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("e")) {
            rotH.Rotate(Vector3.forward * -150 * Time.deltaTime, Space.World);
        }
    }
}
