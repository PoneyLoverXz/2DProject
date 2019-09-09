using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject character;
    private List<ProjectileEmetter> emetters = new List<ProjectileEmetter>();

    void Awake()
    {
        MakeSingleton();
        ProjectileEventBus.Shoot.Connect(Shoot);
    }

    private void OnDestroy()
    {
        ProjectileEventBus.Shoot.Disconnect(Shoot);
    }

    private void Start()
    {
        //TODO: remove when we have a main menu
        InitGame();
    }

    private void OnLevelWasLoaded(int index)
    {
        InitGame();
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

    private void InitGame()
    {
        //Open Loading Screen
        emetters.Clear();
        var audioManager = AudioManager.instance;
        audioManager.ClearAudioList();
        audioManager.PlayLevelMusic();
        Time.timeScale = 1;
        //Close Loading Screen
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

    public void SetCharacter(GameObject gameObject)
    {
        character = gameObject;
    }

    public void AddEmetterToList(ProjectileEmetter emetter)
    {
        emetters.Add(emetter);
    }
}
