using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public List<AudioPeer> audioList = new List<AudioPeer>();
    public List<ProjectileEmetter> emetters = new List<ProjectileEmetter>();
    // Start is called before the first frame update
    void Start()
    {
        foreach(var audio in audioList)
        {
            audio.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < audioList.Count; i++)
        {
            var currentAudio = audioList[i];
            if(currentAudio.canShoot && currentAudio.freqBand > 0.5f)
            {
                currentAudio.canShoot = false;
                EventBus<AudioType>.ShootEventBus.Invoke(currentAudio.audioType);
            }
        }
    }
}
