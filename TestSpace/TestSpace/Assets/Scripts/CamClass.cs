using UnityEngine;

public class CamClass {

    public bool BlB; // Who is allowed here
    public bool YB;
    public bool OB;
    public bool BrB;
    public int IDN; // The ID which this camera is known by (starts at 1)
    public bool BlA; // Who is currently here
    public bool YA;
    public bool OA;
    public bool BrA;
    public Texture camView; // The footage that will be shown in the camera
    public Texture camViewR; // This is the footage that will be reproduced in the monitor
    public Sprite buttonsDisplay; // This is how the buttons get displayed
    public Camera cameraObj; // This is the camera placed in the individual scene

    public void setVEnemy(bool BlC, bool YC, bool OC, bool BrC) {
        BlB = BlC;
        YB = YC;
        OB = OC;
        BrB = BrC;
    } // Set the allowance values

    public void setID(int IDNS) {
        IDN = IDNS;
    } // Set ID number

    public void setActivated(string activationEnemy, bool activeMode) {
        if (activationEnemy == "Bl") {
            BlA = activeMode;
        }
        if (activationEnemy == "Y") {
            YA = activeMode;
        }
        if (activationEnemy == "O") {
            OA = activeMode;
        }
        if (activationEnemy == "Br") {
            BrA = activeMode;
        }
        if (activationEnemy != "Bl" && activationEnemy != "Y" && activationEnemy != "O" && activationEnemy != "Br") {
            Debug.LogError("The enemy \"" + activationEnemy + "\" is not defined");
        }
    } // Activates / deactivates enemy

    public void setCamView(Texture footage, Texture footageR, Sprite activeButton) {
        camView = footage;
        camViewR = footageR;
        buttonsDisplay = activeButton;
    } // Sets a texture for the camera footage and buttons

    public void setCamViewR(Texture newFootageR) {
        camViewR = newFootageR;
    } // Sets a texture only for the camera footage reproduction

    public void setCamObj(Camera sceneCamera) {
        cameraObj = sceneCamera;
    }
}
