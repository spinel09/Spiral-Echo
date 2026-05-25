
using UnityEngine;



public class PlayerMovement : MonoBehaviour
{

    

    public bool hasKey = false;

    private Animator anim;
    
    public float speed = 5f;

    public bool canMove = true;

    private Rigidbody2D rb;

    public Vector2 movement;

    public Vector2 lastMoveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(!canMove)
        {
            movement = Vector2.zero;
            return;
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement.Normalize();
        

        if(movement != Vector2.zero)
        {
            lastMoveDirection = movement;

            anim.SetFloat("MoveX", movement.x);
            anim.SetFloat("MoveY", movement.y);
        }
        else
        {
            anim.SetFloat("MoveX", lastMoveDirection.x);
            anim.SetFloat("MoveY", lastMoveDirection.y);
        }

        

        anim.SetBool("IsMoving", movement != Vector2.zero); 

        
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Key"))
        {
            hasKey = true;

            Destroy(other.gameObject);

            Debug.Log("Clé récupérée !");
        }
    }
}
