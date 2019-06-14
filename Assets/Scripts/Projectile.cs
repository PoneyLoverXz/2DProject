using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float ProjectileSpeed = 0.5f;
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartCoroutine(DestroyProjectile());
    }

    IEnumerator DestroyProjectile()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(gameObject);
    }

    public void ShootInDirection(Vector2 direction)
    {
        _rb.AddForce(direction.normalized * ProjectileSpeed);
    }
}
