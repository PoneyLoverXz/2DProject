using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public GameObject FinishPanel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Time.timeScale = 0;
            AudioManager.instance.StopMusic();
            FinishPanel.SetActive(true);
        }
    }
}
