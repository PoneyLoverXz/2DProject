﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrequencyBand : MonoBehaviour
{
    public AudioPeer audioPeer;
    public float _startScale;
    public float _scaleMultiplier;
    public bool _useBuffer;
    Material _material;
    // Start is called before the first frame update
    void Start()
    {
        _material = GetComponent<MeshRenderer>().materials[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(_useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (audioPeer.freqBand * _scaleMultiplier) + _startScale, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x, (audioPeer.freqBand * _scaleMultiplier) + _startScale, transform.localScale.z);
        }
        Color color = new Color(audioPeer.freqBand, audioPeer.freqBand, audioPeer.freqBand);
        _material.SetColor("_EmissionColor", color);
    }
}
