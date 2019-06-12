using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEmetter : MonoBehaviour
{
    public GameObject projectilePrefab;

    public void Shoot(Vector2 direction)
    {
        var projectileInstance = Instantiate(projectilePrefab, transform);
        projectileInstance.transform.position = transform.position;
        var projectile = projectileInstance.GetComponent<Projectile>();
        projectile.ShootInDirection(direction);
    }
}
