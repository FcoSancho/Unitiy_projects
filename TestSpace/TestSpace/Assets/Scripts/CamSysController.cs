using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CamSysController : MonoBehaviour {

    private TextAsset CamTable;
    private string[][] FullSplitTable;
    private string[] CamNameList;
    private CamClass[] CamClassList;
    public MeshRenderer MonitorPlane;
    private string CurrentCam = "Cam 1A";
    private bool Clicked = false;
    public Camera MainPlayerCam;
    public SpriteRenderer CamButtonsImg;
    public Texture TestingYesCam;

    string[][] TableSplitter() {
        string[] splitTable1 = CamTable.ToString().Split('\n');
        List<string[]> splitTable2 = new List<string[]> (new string[][] {});
        for (int i = 0; i < splitTable1.Length; i++) {
            splitTable2.Add(splitTable1[i].Split(','));
        }
        string[][] splitTable3 = splitTable2.ToArray();

        return splitTable3;
    }

    string[] CamNameLister() {
        List<string> FilledCamNameList = new List<string> (new string[] {});
        for (int i = 1; i < TableSplitter().Length; i++) {
            FilledCamNameList.Add(TableSplitter()[i][0]);
        }
        string[] FilledCamNameArray = FilledCamNameList.ToArray();

        return FilledCamNameArray;
    }

    CamClass[] CamClassLister() {
        List<CamClass> FilledCamClassList = new List<CamClass> (new CamClass[] {});
        for (int i = 0; i < CamNameList.Length; i++) {
            FilledCamClassList.Add(new CamClass ());
        }
        CamClass[] FilledCamClassArray = FilledCamClassList.ToArray();

        return FilledCamClassArray;
    }

    int CamNameToID(string indexVal) {
        int LineVal1 = 0;
        int LineVal2 = 1;
        int indexNum = 0;
        for (int i = 1; i < TableSplitter().Length; i++) {
            if (TableSplitter()[i][0] == indexVal) {
                indexNum = i;
            }
        }
        string IDVal = TableSplitter()[indexNum][1];
        int IDNum = int.Parse(IDVal) - 1;
        return IDNum;
    }

    void Start() {
        CamTable = Resources.Load<TextAsset>("CSVData/GameR1_1");
        FullSplitTable = TableSplitter();
        CamNameList = CamNameLister();
        CamClassList = CamClassLister();

        for (int i = 0; i < CamNameList.Length; i++) {
            CamClassList[CamNameToID(CamNameList[i])].setID(CamNameToID(CamNameList[i]) + 1);
        }
        for (int i = 0; i < CamNameList.Length; i++) {
            CamClassList[CamNameToID(CamNameList[i])].setCamView(TestingYesCam, Resources.Load<Texture>("Images/GameR1CamFootage/" + CamNameList[i].Replace("Cam ", "") + "Footage"), Resources.Load<Sprite>("Images/GameR1CamButtons/camReference" + CamNameList[i].Replace("Cam ", "")));
        }
        for (int i = 0; i < CamNameList.Length; i++) {
            this.gameObject.transform.GetChild(i).gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material.mainTexture = CamClassList[CamNameToID(CamNameList[i])].camView;
        }
        for (int i = 0; i < CamNameList.Length; i++) {
            CamClassList[CamNameToID(CamNameList[i])].setCamObj(this.gameObject.transform.GetChild(i).GetComponent<Camera>());
        }
    }

    void CamButtonClick() {
        Ray ray = MainPlayerCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)) {
            CurrentCam = hit.transform.gameObject.name.Replace("Bu", "").Replace("Cam", "Cam ");
        }

        for (int i = 0; i < CamNameList.Length; i++) {
            if (i == CamNameToID(CurrentCam)) {
                CamClassList[i].cameraObj.targetTexture.Release();
                CamClassList[i].cameraObj.targetTexture = new RenderTexture (500, 500, 24);
                CamClassList[i].setCamViewR(CamClassList[i].cameraObj.targetTexture);
            } else if (i != CamNameToID(CurrentCam)) {
                CamClassList[i].cameraObj.targetTexture.Release();
                CamClassList[i].cameraObj.targetTexture = new RenderTexture (256, 256, 24);
                CamClassList[i].setCamViewR(CamClassList[i].cameraObj.targetTexture);
            }
        }
    }

    void Update() {
        if (Input.GetMouseButtonDown(0) && Clicked == false) {
            Clicked = true;
            CamButtonClick();
        }
        if (!Input.GetMouseButtonDown(0) && Clicked == true) {
            Clicked = false;
        }

        if (MonitorPlane.material.mainTexture != CamClassList[CamNameToID(CurrentCam)].camViewR) {
            MonitorPlane.material.mainTexture = CamClassList[CamNameToID(CurrentCam)].camViewR;
        }
        if (CamButtonsImg.sprite != CamClassList[CamNameToID(CurrentCam)].buttonsDisplay) {
            CamButtonsImg.sprite = CamClassList[CamNameToID(CurrentCam)].buttonsDisplay;
        }
    }
}
