using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIObject : MonoBehaviour
{
    [Header("Аудио")]
    public AudioClip audioOnMouseDown;
    public AudioClip audioOnMouseUp;
    public void MouseDownSound()
    {
        GameObject a = new GameObject();
        a.AddComponent<AudioSource>();
        a.GetComponent<AudioSource>().clip = audioOnMouseDown;
        a.GetComponent<AudioSource>().Play();
        a.AddComponent<LiveAudioPlayer>();
    }
    public void MouseUpSound()
    {
        GameObject a = new GameObject();
        a.AddComponent<AudioSource>();
        a.GetComponent<AudioSource>().clip = audioOnMouseUp;
        a.GetComponent<AudioSource>().Play();
        a.AddComponent<LiveAudioPlayer>();
    }
}
public class LiveAudioPlayer : MonoBehaviour
{
    private void Update()
    {
        if (!GetComponent<AudioSource>().isPlaying) Destroy(gameObject);
    }
}
