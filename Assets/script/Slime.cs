using UnityEngine;
using System.Collections;

public class Slime : Enemy
{

    private Animator anim;


    private bool canMove = true;

    private Transform player;

    public float speed = 2f;

    
   
       


    protected override void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        rb = GetComponent<Rigidbody2D>();

        sr = GetComponent<SpriteRenderer>();

        anim = GetComponent<Animator>();
    }
    

   
    

    void Update()
    {
        if(!GameManager.instance.gameStarted)
        {
            anim.SetBool("IsMoving", false);
            return;
        }

        if(canMove)
        {
            Vector2 direction = 
            (player.position - transform.position).normalized;

            anim.SetFloat("MoveX", direction.x);
            anim.SetFloat("MoveY", direction.y);

            anim.SetBool("IsMoving", true);


             
            Vector2 newPos = Vector2.MoveTowards(
            rb.position,
            player.position,
            speed * Time.deltaTime
            );

            rb.MovePosition(newPos);

            PlayerMovement playerMovement = 
            player.GetComponent<PlayerMovement>();

            if(playerMovement.isInSafeZone)
            {
                anim.SetBool("IsMoving", false);
                return;
            }

        }
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerHealth player = 
        collision.gameObject.GetComponent<PlayerHealth>();

        if(player != null)
        {
            player.TakeDamage(damage);

            Vector2 direction = 
            (transform.position - collision.transform.position).normalized;

            StartCoroutine(AttackCooldown());
        }
    }

    IEnumerator AttackCooldown()
    {
        canMove = false;

        anim.SetBool("IsMoving",false);

        yield return new WaitForSeconds(0.5f);

        canMove = true; 

        anim.SetBool("IsMoving", true);
    }






    IEnumerator DieAfterHit()
    {
        yield return new WaitForSeconds(0.15f);

        Debug.Log(GameManager.instance);

        GameManager.instance.SlimeKilled();

        Destroy(gameObject);
    }

}
