using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEmetter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Animator animator;
    public EmetterType emetterType = EmetterType.StraightLine;
    public AudioType audioType = AudioType.Lead;

    private GameManager gameManager;

    public void Awake()
    {
        gameManager = GameManager.instance;
    }

    public void Shoot()
    {
        var directions = GetDirection();
        foreach (var direction in directions)
        {
            animator.SetBool("Pulse", false);
            var projectileInstance = Instantiate(projectilePrefab, transform);
            projectileInstance.transform.position = transform.position;
            var projectile = projectileInstance.GetComponent<Projectile>();
            projectile.ShootInDirection(direction);
            animator.SetBool("Pulse", true);
        }

    }

    private List<Vector2> GetDirection()
    {
        switch(emetterType)
        {
            case EmetterType.StraightLine:
                return new List<Vector2>() { transform.right };
            case EmetterType.TowardsCharacter:
                return new List<Vector2>() { gameManager.GetCharacterPosition() - transform.position };
            case EmetterType.Everywhere:
                var directions = new List<Vector2>();
                directions.Add(new Vector2(0, 1));
                directions.Add(new Vector2(1, 0));
                directions.Add(new Vector2(1, 1));
                directions.Add(new Vector2(-1, 0));
                directions.Add(new Vector2(0, -1));
                directions.Add(new Vector2(-1, -1));
                directions.Add(new Vector2(1, -1));
                directions.Add(new Vector2(-1, 1));

                return directions;
        }
        return new List<Vector2>() { transform.right };
    }

    private void OnAnimationEvent()
    {
        animator.SetBool("Pulse", false);
    }
}
