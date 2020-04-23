using UnityEngine;

public class EndTrigger : MonoBehaviour {

    public GameManager gameManager;

    void OnTriggerEnter() {
        if (Score.scoreValue > Score.highscoreValue) {
            Score.highscoreValue = Score.scoreValue;
        }

        if (Score.highscoreValue > GameManager.highScoreStorage) {
            GameManager.highScoreStorage = Score.highscoreValue;
        }
        gameManager.CompleteLevel();
    }
}
