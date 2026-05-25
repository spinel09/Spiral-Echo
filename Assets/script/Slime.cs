using UnityEngine;
using System.Collections;

public class Slime : MonoBehaviour
{

    private bool canMove = true;

    private Transform player;

    public float speed = 2f;
    public GameObject key;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Die()
    {
        key.transform.parent = null;

        key.SetActive(true);

        Destroy(gameObject);
    }

    void Update()
    {
        if(canMove)
        {
             transform.position = Vector2.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime
        );

        }
       
        
        if(Input.GetKeyDown(KeyCode.K))
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerHealth player = 
        collision.gameObject.GetComponent<PlayerHealth>();

        if(player != null)
        {
            player.TakeDamage(1);

            Vector2 direction = 
            (transform.position - collision.transform.position).normalized;

            transform.position += (Vector3)(direction * 2f);
            StartCoroutine(AttackCooldown());
        }
    }

    IEnumerator AttackCooldown()
    {
        canMove = false;

        yield return new WaitForSeconds(0.5f);

        canMove = true; 
    }
}
