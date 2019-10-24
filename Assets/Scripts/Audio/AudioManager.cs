using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public List<AudioPeer> audioList = new List<AudioPeer>();
    public PlayableDirector timeline;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
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

        timeline.Play();

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
