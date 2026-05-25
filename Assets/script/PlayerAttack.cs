using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform attackPoint;

    public float attackRange= 1f;

    public LayerMask enemyLayer;


    private PlayerMovement playerMovement;


    void Start()
    {
       playerMovement = GetComponent<PlayerMovement>(); 
    }

    void Update()
    {
        attackPoint.localPosition = 
            playerMovement.lastMoveDirection * 0.5f;



        if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void Attack()
    {
        Collider2D[] hitEnemis = Physics2D .OverlapCircleAll(
            attackPoint.position,
            attackRange,
            enemyLayer
        );

        Debug.Log(hitEnemis.Length);

        foreach(Collider2D enemy in hitEnemis)
        {
            enemy.GetComponent<Slime>().Die();
        }
    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        return;

        Gizmos.color = Color.red;


        Gizmos.DrawWireSphere(
            attackPoint.position,
            attackRange
        );
    }
}
