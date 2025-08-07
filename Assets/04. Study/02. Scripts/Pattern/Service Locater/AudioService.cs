using UnityEngine;

public class AudioService : IAudioService
{
    public void PlaySound()
    {
        Debug.Log("play sound");
    }

    public void Stopsound()
    {
        Debug.Log("Stop sound");
    }
}