using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{

    private bool canAttack = true;

    public GameObject slashPrefab;
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



        if(Input.GetKeyDown(KeyCode.Space) && canAttack)
        {
            Attack();

            StartCoroutine(AttackCooldown());
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


        GameObject slash = Instantiate(
            slashPrefab,
            attackPoint.position,
            Quaternion.identity
        );

        Vector2 dir = playerMovement.lastMoveDirection;

        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;

        slash.transform.rotation = Quaternion.Euler(0,0, angle);

        foreach(Collider2D enemy in hitEnemis)
        {
            Vector2 hitDir = 
            (enemy.transform.position - transform.position).normalized;

            Enemy enemyScript = 
            enemy.GetComponent<Enemy>();

            if(enemyScript != null)
            {
                enemyScript.TakeHit(hitDir);
            }
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

    IEnumerator AttackCooldown()
    {
        canAttack = false;

        yield return new WaitForSeconds(0.3f);

        canAttack = true;
    }
}
