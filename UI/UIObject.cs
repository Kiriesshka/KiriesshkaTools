using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIObject : MonoBehaviour
{
    [Header("Звуки при взаимодействии")]
    public AudioClip audioOnMouseDown;
    public AudioClip audioOnMouseUp;
    public AudioClip audioOnMouseEnter;
    public AudioClip audioOnMouseExit;

    private EventTrigger eventTrigger;
    private void Start()
    {
        if (audioOnMouseDown || audioOnMouseUp || audioOnMouseEnter || audioOnMouseExit)
        {
            eventTrigger = gameObject.AddComponent<EventTrigger>();
            if (audioOnMouseDown)
            {
                EventTrigger.Entry entry = new EventTrigger.Entry();
                entry.eventID = EventTriggerType.PointerDown;
                entry.callback.AddListener((eventData) => { MouseDownSound(); });
                eventTrigger.triggers.Add(entry);
            }
            if (audioOnMouseUp)
            {
                EventTrigger.Entry entry = new EventTrigger.Entry();
                entry.eventID = EventTriggerType.PointerUp;
                entry.callback.AddListener((eventData) => { MouseUpSound(); });
                eventTrigger.triggers.Add(entry);
            }
            if (audioOnMouseEnter)
            {
                EventTrigger.Entry entry = new EventTrigger.Entry();
                entry.eventID = EventTriggerType.PointerEnter;
                entry.callback.AddListener((eventData) => { MouseEnterSound(); });
                eventTrigger.triggers.Add(entry);
            }
            if (audioOnMouseExit)
            {
                EventTrigger.Entry entry = new EventTrigger.Entry();
                entry.eventID = EventTriggerType.PointerExit;
                entry.callback.AddListener((eventData) => { MouseExitSound(); });
                eventTrigger.triggers.Add(entry);
            }
        }
    }
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
    public void MouseEnterSound()
    {
        GameObject a = new GameObject();
        a.AddComponent<AudioSource>();
        a.GetComponent<AudioSource>().clip = audioOnMouseEnter;
        a.GetComponent<AudioSource>().Play();
        a.AddComponent<LiveAudioPlayer>();
    }
    public void MouseExitSound()
    {
        GameObject a = new GameObject();
        a.AddComponent<AudioSource>();
        a.GetComponent<AudioSource>().clip = audioOnMouseExit;
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
