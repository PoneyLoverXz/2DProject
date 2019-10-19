using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private List<AudioPeer> audioList = new List<AudioPeer>();

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
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

    public void InitGame()
    {
        PlayLevelMusic();
    }

    private void PlayLevelMusic()
    {
        StartCoroutine(PlayAudio());
    }

    public void AddAudioPeerToList(AudioPeer audioPeer)
    {
        audioList.Add(audioPeer);
    }

    private void ClearAudioList()
    {
        audioList.Clear();
    }

    private IEnumerator PlayAudio()
    {
        yield return new WaitForSeconds(2);

        foreach (var audio in audioList)
        {
            audio.Play();
        }

        yield break;
    }

    public void StopMusic()
    {
        foreach (var audio in audioList)
        {
            audio.Stop();
        }
    }
}
