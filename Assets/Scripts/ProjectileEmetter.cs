using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEmetter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public EmetterType emetterType = EmetterType.StraightLine;
    public AudioType audioType = AudioType.Lead;

    private GameManager gameManager;

    public void Awake()
    {
        gameManager = GameManager.instance;
    }

    public void Shoot()
    {
        var projectileInstance = Instantiate(projectilePrefab, transform);
        projectileInstance.transform.position = transform.position;
        var projectile = projectileInstance.GetComponent<Projectile>();
        projectile.ShootInDirection(GetDirection());
    }

    private Vector2 GetDirection()
    {
        switch(emetterType)
        {
            case EmetterType.StraightLine:
                return transform.right;
            case EmetterType.TowardsCharacter:
                return (gameManager.GetCharacterPosition() - transform.position);
            //TODO: case EmetterType.Everywhere: 
        }
        return new Vector2(1, 0);
    }
}
