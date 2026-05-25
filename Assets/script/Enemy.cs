using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public int health = 3;

    protected Rigidbody2D rb;

    protected SpriteRenderer sr;

    public int damage = 1;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        sr = GetComponent<SpriteRenderer>();
    }

    public virtual void TakeHit(Vector2 direction)
    {
        health--;
        
        rb.linearVelocity = direction * 5f;

        StartCoroutine(HitFlash());

        StartCoroutine(StopKnockback());

        Debug.Log(gameObject.name + " hp : " + health);

        if(health <= 0)
        {
            Die();
        }
    }

    protected IEnumerator HitFlash()
    {
        sr.color = Color.red;

        yield return new WaitForSeconds(0.1f);

        sr.color = Color.white;
    }

    protected IEnumerator StopKnockback()
    {
        yield return new WaitForSeconds(0.1f);

        rb.linearVelocity = Vector2.zero;
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
