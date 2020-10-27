using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectionStatus : MonoBehaviour {

    List<InfectedState> infectState = new List<InfectedState>();

    void Start() {
        TextAsset infectionStatus = Resources.Load<TextAsset>("CSVData/InfectedGame");

        string[] data = infectionStatus.text.Split(new char[] { '\n' });

        for (int i = 1; i < data.Length; i++) {
            string[] row = data[i].Split(new char[] { ',' });

            if (row[1] != "") {
                InfectedState q = new InfectedState();
                q.empty = row[0];
                q.infected = row[1];
                q.safe = row[2];
                q.player = row[3];

            infectState.Add(q);
            }
        }

        /*foreach (InfectedState inf in infectState) {
            Debug.Log(inf.empty + ", " + inf.infected + ", " + inf.safe + ", " + inf.player);
        }*/
    }

    void Update() {
        
    }
}
