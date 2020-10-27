using UnityEngine;
using UnityEngine.UI;

public class TopBarSetting : MonoBehaviour {

    public RectTransform tab;
    public RectTransform BH;

    private void Start() {
        tab.offsetMin = new Vector2(tab.offsetMin.x, (((float) (500 * Screen.height)) / ((float) (Screen.width * 322))) * 450);
        BH.offsetMin = new Vector2(tab.offsetMin.x, (((float) (500 * Screen.height)) / ((float) (Screen.width * 322))) * 450);
    }

    private void Update() {
        tab.offsetMin = new Vector2(tab.offsetMin.x, (((float) (500 * Screen.height)) / ((float) (Screen.width * 322))) * 450);
        BH.offsetMin = new Vector2(tab.offsetMin.x, (((float) (500 * Screen.height)) / ((float) (Screen.width * 322))) * 450);
    }
}
