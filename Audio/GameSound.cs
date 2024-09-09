using System.Collections.Generic;
using UnityEngine;

public class GameSound : MonoBehaviour
{
    public string audioFolder;
    public List<string> soundChannels;
    public List<float> channelsVolumeSettings;
    public void MakeSound(string soundName, string soundChannel)
    {
        if (!soundChannels.Contains(soundChannel))
        {
            Debug.LogError("No sound channel with name: [" + soundChannel + "]");
            return;
        }
        if(channelsVolumeSettings.Count < soundChannels.Count)
        {
            Debug.Log("No volume settings for all of sound channels");
            return;
        }
        GameObject soundObj = new GameObject();
        soundObj.name = soundChannel + "->" + soundName;
        soundObj.AddComponent<AudioSource>();
        soundObj.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>(audioFolder + "/"+soundName);
        soundObj.GetComponent<AudioSource>().volume = channelsVolumeSettings[soundChannels.IndexOf(soundChannel)];
        soundObj.GetComponent<AudioSource>().Play();
        soundObj.AddComponent<DestroyAfterAudioStop>();
    }
}
public class DestroyAfterAudioStop : MonoBehaviour
{
    private void Update()
    {
        if(!GetComponent<AudioSource>().isPlaying) Destroy(gameObject);
    }
}