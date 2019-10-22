using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HUDManager : MonoBehaviour
{
    public static HUDManager instance;

    [Header("Health")]
    public List<Image> _hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    [Header("Collectibles")]
    public TMP_Text coinAmountText;
    private int coinAmount;

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
        }
    }

    public void UpdateHealth(int currentHealth)
    {
        for (int i = 0; i < _hearts.Count; i++)
        {
            if (i < currentHealth)
                _hearts[i].sprite = fullHeart;
            else
                _hearts[i].sprite = emptyHeart;
        }
    }

    public void UpdateCoinCollected(int amountCollected)
    {
        coinAmount += amountCollected;

        coinAmountText.text = coinAmount.ToString();
    }

    public void resetCollectibles()
    {
        coinAmount = 0;
        coinAmountText.text = coinAmount.ToString();
    }
}
