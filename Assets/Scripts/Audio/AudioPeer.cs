using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class AudioPeer : MonoBehaviour
{
    private AudioSource _audioSource;

    float[] samples = new float[512];
    private float shootFrequency = 1;

    [HideInInspector]
    public float freqBand = 0;
    [HideInInspector]
    public bool canShoot = true;

    public AudioType audioType = AudioType.Other;
    
    //Used for testing
    //public List<float> audioBands = new List<float>();

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        GetSpectrumAudioSource();
        MakeFrequencyBand();
    }

    public void Play()
    {
        _audioSource?.Play();
    }

    public void Stop()
    {
        _audioSource?.Stop();
    }

    private void GetSpectrumAudioSource()
    {
        _audioSource.GetSpectrumData(samples, 0, FFTWindow.Rectangular);
    }

    void MakeFrequencyBand()
    {
        var lastFreq = freqBand;

        var total = 0.0f;
        var count = samples.Length;
        for (int i = 0; i < count; ++i)
        {
            var currentSample = samples[i] < 0.001 ? 0 : samples[i];

            total += currentSample;
        }

        var average = total / count;

        freqBand = average * 1000;

        if (freqBand < 0.2 || (freqBand/lastFreq) > 2)
        {
            canShoot = true;
        }

        //Used for testing
        //audioBands.Add(freqBand);
    }

    /*
     * 
    float _bandBuffer = 0;
    float _bufferDecrease = 0;
    void BandBuffer()
    {
        if (freqBand > _bandBuffer)
        {
            _bandBuffer = freqBand;
            _bufferDecrease = 0.05f;
        }
        else if (freqBand < _bandBuffer)
        {
            _bandBuffer -= _bufferDecrease;
            _bufferDecrease*= 1.2f;
        }
    }
    */
}
