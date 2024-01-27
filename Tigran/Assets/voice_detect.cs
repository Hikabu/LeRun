using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voice_detect : MonoBehaviour
{
    public int sampleWindow = 64;
    private AudioClip microphoneClip;
    // Start is called before the first frame update
    void Start()
    {
        // foreach (var device in Microphone.devices)
        // {
        //     Debug.Log("Name: " + device);
        // }
        MicrofoneToAudioClip();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MicrofoneToAudioClip()
    {
        string microphoneName = Microphone.devices[0];
        microphoneClip = Microphone.Start(microphoneName, true, 20, AudioSettings.outputSampleRate);
    }

    public float GetLoudnessFromMicrophone()
    {
        return GetLoudness(Microphone.GetPosition(Microphone.devices[0]), microphoneClip);
    }

    public float GetLoudness(int clipPosition, AudioClip clip)
    {
        int startPositon = clipPosition - sampleWindow;
        if (startPositon < 0)
            return 0;
        float[] waveData = new float[sampleWindow];
        clip.GetData(waveData, startPositon);

        //compute loudness
        float totalLoudness = 0;

        for (int i = 0; i < sampleWindow; i++)
        {
            totalLoudness += Mathf.Abs(waveData[i]);
        }
        return totalLoudness / sampleWindow;
    }
}
