using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject character;
    public List<ProjectileEmetter> emetters;

    void Awake()
    {
        MakeSingleton();
        ProjectileEventBus.Shoot.Connect(Shoot);
    }

    private void OnDestroy()
    {
        ProjectileEventBus.Shoot.Disconnect(Shoot);
    }

    private void MakeSingleton()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Shoot(AudioType audioType)
    {
        foreach(var emetter in emetters)
        {
            if(audioType == emetter.audioType)
                emetter.Shoot();
        }
    }

    public Vector3 GetCharacterPosition()
    {
        return character.transform.position;
    }
}
