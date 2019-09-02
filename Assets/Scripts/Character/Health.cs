using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public List<Image> _hearts;

    public Sprite fullHeart;
    public Sprite emptyHeart;

    public int health;
    public bool canTakeDamage = true;
    public int avoidSeconds;

    public Vector3 StartPosition;

    private void Update()
    {
        if(health <= 0)
        {
            transform.localPosition = StartPosition;
            health = _hearts.Count;
        }
        UpdateUI();
    }

    public void LoseHealth(int damage)
    {
        if(canTakeDamage)
        {
            health -= damage;
            canTakeDamage = false;
            StartCoroutine(AvoidDamageFor(avoidSeconds));
        }
    }

    private IEnumerator AvoidDamageFor(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        canTakeDamage = true;
        yield break;
    }

    private void UpdateUI()
    {
        for (int i = 0; i < _hearts.Count; i++)
        {
            if (i < health)
                _hearts[i].sprite = fullHeart;
            else
                _hearts[i].sprite = emptyHeart;
        }
    }
}
