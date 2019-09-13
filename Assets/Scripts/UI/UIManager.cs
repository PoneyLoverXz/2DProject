using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public WinPanel winPanel;

    public GameOverPanel gameOverPanel;

    public Image alphaGray;

    // Start is called before the first frame update
    void Awake()
    {
        MakeSingleton();
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
            DontDestroyOnLoad(gameObject);
        }
    }

    public void InitGame()
    {
        winPanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(false);
        alphaGray.gameObject.SetActive(false);
    }

    public void ShowWin()
    {
        winPanel.gameObject.SetActive(true);
    }

    public void ShowGameOver()
    {
        gameOverPanel.gameObject.SetActive(true);
    }

    public void ShowAlphaGray()
    {
        alphaGray.gameObject.SetActive(true);
    }
}
