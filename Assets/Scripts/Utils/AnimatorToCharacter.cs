using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorToCharacter : MonoBehaviour
{
    public void OnDeathAnimationEnd()
    {
        GameManager.instance.GameOver();
    }
}
