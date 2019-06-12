using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameObject character;
    public static GameObject emetter;

    float time = 0f;
    float timer = .5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= timer)
        {
            time = time - timer;

            //emetter.GetComponent<ProjectileEmetter>().Shoot(character.transform.position - emetter.transform.position);
        }
    }

    public static void Shoot()
    {
        emetter.GetComponent<ProjectileEmetter>().Shoot(character.transform.position - emetter.transform.position);
    }
}
