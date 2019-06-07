using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class AudioPeer : MonoBehaviour
{
    private AudioSource _audioSource;

    private const int AMOUNT_OF_BANDS = 6;

    public float[] samples = new float[512];
    float _freqBand = 0;
    float _bandBuffer = 0;
    float _bufferDecrease = 0;
    float _freqBandHighest = 0;

    public float audioBand = 0;
    public  float audioBandBuffer = 0;

    public float amplitude;
    public float amplitudeBuffer;
    float _amplitudeHighest;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        GetSpectrumAudioSource();
        MakeFrequencyBand();
       // BandBuffer();
        CreateAudioBand();
        //GetAmplitude();
    }

    public void Play()
    {
        _audioSource.Play();
    }

    private void GetSpectrumAudioSource()
    {
        _audioSource.GetSpectrumData(samples, 0, FFTWindow.Rectangular);
    }

    void MakeFrequencyBand()
    {
        var total = 0.0f;
        var count = samples.Length;
        for (int i = 0; i < count; ++i)
        {
            var currentSample = samples[i] < 0.001 ? 0 : samples[i];

            total += currentSample;
        }

        var average = total / count;

        _freqBand = average * 100;
    }

    private void CreateAudioBand()
    {
        if(_freqBand > _freqBandHighest)
        {
            _freqBandHighest = _freqBand;
        }
        audioBand = (_freqBand / _freqBandHighest);
        //audioBandBuffer = (_bandBuffer / _freqBandHighest);
    }

    void BandBuffer()
    {
        if (_freqBand > _bandBuffer)
        {
            _bandBuffer = _freqBand;
            _bufferDecrease = 0.05f;
        }
        else if (_freqBand < _bandBuffer)
        {
            _bandBuffer -= _bufferDecrease;
            _bufferDecrease*= 1.2f;
        }
    }

    private void GetAmplitude()
    {
        if (audioBand > _amplitudeHighest)
        {
            _amplitudeHighest = audioBand;
        }

        amplitude = audioBand / _amplitudeHighest;
        amplitudeBuffer = amplitude / _amplitudeHighest;
    }
}
