using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public bool gameHasEnded = false;

    //public float restartDelay = 1f;

    public Text GameOverTextDisplay;

    public Text RestartInstructions;

    public GameObject CompleteLevelUI;

    public static int highScoreStorage = 0;

    public static int highScoreStorageReturn;

    public static bool keepScoreGrowth = true;

    public void CompleteLevel() {
        CompleteLevelUI.SetActive(true);
    }

    public void EndGame() {
        if (Score.scoreValue > Score.highscoreValue) {
            Score.highscoreValue = Score.scoreValue;
        }

        if (Score.highscoreValue > highScoreStorage) {
            highScoreStorage = Score.highscoreValue;
        }

        if (gameHasEnded == false) {
            gameHasEnded = true;
            //Debug.Log("GAME OVER!");
            //Invoke("Restart", restartDelay);
        }
    }

    void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Update() {
        if (gameHasEnded == true) {
            keepScoreGrowth = false;
        } else if (gameHasEnded == false) {
            keepScoreGrowth = true;
        }

        highScoreStorageReturn = highScoreStorage;
        
        if (Input.GetKey("r") && gameHasEnded == true) {
                Restart();
        }

        if (Input.GetKey("enter") && gameHasEnded == true) {
                Restart();
        }
        
        if (Input.GetKey("return") && gameHasEnded == true) {
                Restart();
        }

        if (gameHasEnded == true) {
            GameOverTextDisplay.text = "Game Over!";
        }

        if (gameHasEnded == false) {
            GameOverTextDisplay.text = "";
        }

        if (gameHasEnded == true) {
        RestartInstructions.text = "Press \"R\" or \"Enter\" to restart";
        }

        if (gameHasEnded == false) {
            RestartInstructions.text = "";
        }
    }
}
