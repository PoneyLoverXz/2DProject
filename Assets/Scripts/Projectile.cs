using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D _rb;
    public int ProjectileSpeed = 1;
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

    }

    public void ShootInDirection(Vector2 direction)
    {
        _rb.AddForce(direction.normalized * ProjectileSpeed);
    }
}
