using UnityEngine;
using System;

public class AudioManager : MonoBehaviour {
    // Use it as a Singleton
    public static AudioManager Instance;

    [SerializeField] private Sound[] _sounds;

    void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            // If there already was an instance of this object, destroy it to make this the only one
            Destroy(gameObject);
            return;
        }

        // Preserves this object instance when changing scenes
        DontDestroyOnLoad(gameObject);

        SetUpSounds();
    }

    void SetUpSounds() {
        foreach (Sound sound in _sounds) {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.audioClip;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.pitch = sound.pitch;
            sound.audioSource.loop = sound.loop;
        }
    }

    public void Play(string name) {
        Sound sound = Array.Find(_sounds, sound => sound.name == name);
        if (sound != null) {
            sound.audioSource.Play();
            Debug.Log("I played a sound!");
        } else {
            Debug.Log("A Sound is null :(");
        }
    }

    public void Stop(string name) {
        Sound sound = Array.Find(_sounds, sound => sound.name == name);
        sound?.audioSource.Stop();
    }
}
