using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmetterManager : MonoBehaviour
{
    public static EmetterManager instance;

    public List<ProjectileEmetter> emetters = new List<ProjectileEmetter>();
    public Character character;

    // Start is called before the first frame update
    void Awake()
    {
        ProjectileEventBus.Shoot.Connect(Shoot);

        MakeSingleton();
    }

    private void OnDestroy()
    {
        ProjectileEventBus.Shoot.Disconnect(Shoot);
    }

    private void MakeSingleton()
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

    public void Shoot(AudioType audioType)
    {
        foreach (var emetter in emetters)
        {
           // if (audioType == emetter.audioType)
                //emetter.Shoot();
        }
    }

    public Vector3 GetCharacterPosition()
    {
        return character.transform.position;
    }

    public void LoseHealth(int damage)
    {
        character.LoseHealth(damage);
    }

    public void SetCharacter(Character character)
    {
        this.character = character;
    }

    public void AddEmetterToList(ProjectileEmetter emetter)
    {
        emetters.Add(emetter);
    }
}
