using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Character character;
    //TODO: implement pause menu or pause when character dying + animation
    public bool gamePaused = false;
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

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
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
        AudioManager.instance.InitGame();
        UIManager.instance.InitGame();
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

    public void Win()
    {
        Time.timeScale = 0;
        AudioManager.instance.StopMusic();
        UIManager.instance.ShowWin();
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        AudioManager.instance.StopMusic();
        UIManager.instance.alphaGray.gameObject.SetActive(false);
        UIManager.instance.ShowGameOver();
    }
}
