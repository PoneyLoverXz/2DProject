using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public GameObject audioHolder;
    private List<AudioPeer> audioList = new List<AudioPeer>();

    private void Awake()
    {
       audioList = audioHolder.GetComponentsInChildren<AudioPeer>().ToList();
    }

    void Start()
    {
        StartCoroutine(PlayAudio());
    }

    void Update()
    {
        for(int i = 0; i < audioList.Count; i++)
        {
            var currentAudio = audioList[i];
            if(currentAudio.canShoot && currentAudio.freqBand > 0.5f)
            {
                currentAudio.canShoot = false;
                ProjectileEventBus.Shoot.Invoke(currentAudio.audioType);
            }
        }
    }

    IEnumerator PlayAudio()
    {
        yield return new WaitForSeconds(2);

        foreach (var audio in audioList)
        {
            audio.Play();
        }

        yield break;
    }
}
