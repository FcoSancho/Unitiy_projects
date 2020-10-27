using UnityEngine;
using UnityEngine.Audio;

public class AudioClipPlayer {

    public GameObject audioObject;
    public AudioSource source;
    private Vector3 _objectStartLocation;
    private float _startPitch;
    private float _startVolume;
    private AudioClip _startAudioClip;

    public AudioClipPlayer(GameObject newObject, AudioClip clip, float volume = 1f, float pitch = 1f, Vector3 objectPosition = default(Vector3)) {
        _objectStartLocation = objectPosition;
        audioObject = Object.Instantiate(newObject, objectPosition, Quaternion.identity);
        audioObject.AddComponent<AudioSource>();
        audioObject.GetComponent<AudioSource>().pitch = pitch;
        audioObject.GetComponent<AudioSource>().volume = volume;
        audioObject.GetComponent<AudioSource>().clip = clip;
        source = audioObject.GetComponent<AudioSource>();
    }

    public void destroyObject() {
    }

    public void createObject(GameObject newObject, AudioClip clip = null, float? volume = null, float? pitch = null, Vector3? objectPosition = null) {
        if (clip != null) {_startAudioClip = clip;}
        if (volume != null) {_startVolume = volume.GetValueOrDefault();}
        if (pitch != null) {_startPitch = pitch.GetValueOrDefault();}
        if (objectPosition != null) {_objectStartLocation = objectPosition.GetValueOrDefault();}
    }
}
