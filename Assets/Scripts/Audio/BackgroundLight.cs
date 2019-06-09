using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLight : MonoBehaviour
{
    public AudioPeer audioPeer;
    public float _minIntensity, _maxIntensity;
    private Light _light;
    // Start is called before the first frame update
    void Start()
    {
        _light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        _light.intensity = (audioPeer.freqBand * (_maxIntensity - _minIntensity)) + _minIntensity;
    }
}
