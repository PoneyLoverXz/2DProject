using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D _rb;
    public int damage;

    public LayerMask groundLayer;

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
        yield return new WaitForSeconds(10.0f);
        Destroy(gameObject);
    }

    public void ShootInDirection(Vector2 direction, float speed)
    {
        _rb.AddForce(direction.normalized * speed * 500);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (groundLayer == (groundLayer | (1 << other.gameObject.layer)))
            Destroy(gameObject);
    }

}
