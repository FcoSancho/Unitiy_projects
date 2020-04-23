using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Transform player;
    public Text scoreText;
    public Text highscoreText;
    public static int scoreValue = 0;
    public static int highscoreValue = 0;

    void Start() {
        /*int distance = (int) player.position.z;
        highscoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString("0");*/
    }

    // Update is called once per frame
    void Update() {
        //PlayerPrefs.SetInt("highScore", distance);
        GetHighscore();
        scoreText.text = "Score: " + scoreValue.ToString(/*"0"*/);
    }

    void GetHighscore() {
       /*float high = player.position.z;
        PlayerPrefs.SetFloat("highScore", high);*/
        if (GameManager.keepScoreGrowth == true) {
            scoreValue = (int) player.position.z;
        }
        highscoreValue = 0;
        if (scoreValue > highscoreValue) {
            highscoreValue = scoreValue;
        }

        if (highscoreValue >= GameManager.highScoreStorageReturn) {
            highscoreText.text = "Highscore: " + highscoreValue;
        } else if (highscoreValue < GameManager.highScoreStorageReturn) {
            highscoreText.text = "Highscore: " + GameManager.highScoreStorageReturn;
        }
    }
}
