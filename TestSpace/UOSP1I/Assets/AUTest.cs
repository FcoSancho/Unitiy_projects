using UnityEngine;
using UnityEngine.Audio;

public class AUTest : MonoBehaviour {

    private AudioClipPlayer y;
    public AudioClip z;
    public bool b;

    private void Start() {
        GameObject x = new GameObject();
        y = new AudioClipPlayer(x, z, 1, 1);
        Destroy(x);
        y.source.loop = true;
        y.source.Play();
    }

    private void Update() {
        if (b && !y.source.isPlaying) {
            y.source.UnPause();
        } else if (!b && y.source.isPlaying) {
            y.source.Pause();
        }
    }
}
