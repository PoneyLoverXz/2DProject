using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject character;
    public GameObject emetterHolder;
    private List<ProjectileEmetter> emetters;

    void Awake()
    {
        MakeSingleton();
        ProjectileEventBus.Shoot.Connect(Shoot);
        CharacterEventBus.LoseHealth.Connect(LoseHealth);
        emetters = emetterHolder.GetComponentsInChildren<ProjectileEmetter>().ToList();
    }

    private void OnDestroy()
    {
        ProjectileEventBus.Shoot.Disconnect(Shoot);
        CharacterEventBus.LoseHealth.Connect(LoseHealth);
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
    
    public void LoseHealth(int damage)
    {
        var health = character.GetComponent<Health>();
        health.LoseHealth(damage);
    }
}
