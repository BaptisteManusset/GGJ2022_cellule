using UnityEngine;

public class AudioManager : MonoBehaviour {
    private static AudioManager _instance;

    public static AudioManager Instance {
        get {
            _instance = FindObjectOfType<AudioManager>();

            return _instance;
        }
    }

    private AudioSource _audioSource;

    private void Awake() {
        _audioSource = GetComponent<AudioSource>();
    }


    public void PlaySound(AudioClip audioClip) {
        _audioSource.pitch = Random.Range(.5f, 1.5f);
        _audioSource.PlayOneShot(audioClip);
    }
}