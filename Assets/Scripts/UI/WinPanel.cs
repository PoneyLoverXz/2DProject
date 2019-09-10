using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinPanel : MonoBehaviour
{
    private Button restartButton;
            
    public void RestartClicked()
    {
        SceneManager.LoadScene("scene");
    }
}
