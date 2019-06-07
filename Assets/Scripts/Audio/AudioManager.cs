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
            if(audioList[i].audioBand > 0.4f)
            {
                emetters[i].Shoot(new Vector2(1,0));
            }
        }
    }
}
