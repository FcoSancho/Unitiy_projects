using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TextReset : MonoBehaviour {

    public InputField inTxt;
    private string words;
    private int upper;
    private int lower;
    private int ascii;
    private bool CL = false;
    public GameObject inpt1;
    public GameObject inpt2;
    public GameObject inpt3;
    public Toggle sync;
    [System.Runtime.InteropServices.DllImport("USER32.dll")] public static extern short GetKeyState(int nVirtKey); bool IsCapsLockOn => (GetKeyState(0x14) & 1) > 0;
    private bool press = false;
    public Text ONAOFF;
    public Dropdown dd;
    public GameObject inpt4;
    public Text BMode;
    public GameObject BM;
    public GameObject battWarn;

    void Update() {
        if (dd.options[dd.value].text == "Capslock mode") {
            inpt4.SetActive(true);
        }

        if (dd.options[dd.value].text != "Capslock mode") {
            inpt4.SetActive(false);
        }

        if (dd.options[dd.value].text == "Capslock mode") {
            if (sync.isOn == false) {
                inpt1.SetActive(true);
                inpt2.SetActive(true);
                inpt3.SetActive(true);
            }

            if (sync.isOn == true) {
                inpt1.SetActive(false);
                inpt2.SetActive(false);
                inpt3.SetActive(false);
            }

            if (sync.isOn == true) {
                CL = IsCapsLockOn;
            }

            if (sync.isOn == false) {
                if (inTxt.text != "") {
                    words = inTxt.text;
                    upper = 0;
                    lower = 0;

                    foreach (char c in words) {
                        ascii = c;

                        if (ascii > 65 && ascii < 90) {
                            upper += 1;
                        }

                        if (ascii > 97 && ascii < 122) {
                            lower += 1;
                        }
                    }

                    if (lower > upper) {
                        CL = false;
                    }

                    if (lower < upper) {
                        CL = true;
                    }
                }

                if (CL == true && Input.GetKey(KeyCode.CapsLock) && press == false) {
                    CL = false;
                    press = true;
                }

                if (CL == false && Input.GetKey(KeyCode.CapsLock) && press == false) {
                    CL = true;
                    press = true;
                }

                if (!Input.GetKey(KeyCode.CapsLock)) {
                    press = false;
                }
            }

            inTxt.text = "";

            if (CL == false) {
                ONAOFF.text = "OFF";
            }

            if (CL == true) {
                ONAOFF.text = "ON";
            }
        }

        if (dd.options[dd.value].text == "Battery mode") {
            BM.SetActive(true);
        }

        if (dd.options[dd.value].text != "Battery mode") {
            BM.SetActive(false);
        }

        if (dd.options[dd.value].text == "Battery mode") {
            ONAOFF.text = (SystemInfo.batteryLevel * 100).ToString() + "%";
            if (SystemInfo.batteryStatus.ToString() != "NotCharging") {
                BMode.text = SystemInfo.batteryStatus.ToString();
            }

            if (SystemInfo.batteryStatus.ToString() == "NotCharging") {
                BMode.text = "Not Charging";
            }
        }

        if ((SystemInfo.batteryLevel * 100) <= 20) {
            battWarn.SetActive(true);
        }

        if ((SystemInfo.batteryLevel * 100) >= 20) {
            battWarn.SetActive(false);
        }
    }
}
