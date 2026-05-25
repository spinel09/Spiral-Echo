using UnityEngine;
using System.Collections;

public class SlimeAttack : MonoBehaviour
{

    public int health = 5;

    private bool canDamage = false;
    void Start()
    {
       StartCoroutine(AttackRoutine());
    }
    IEnumerator AttackRoutine()
    {
        yield return new WaitForSeconds(0.2f);

        canDamage = true;

        yield return new WaitForSeconds(0.8f);

        Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(!canDamage)
        return;

        PlayerHealth player = 
        other.GetComponent<PlayerHealth>();

        if(player != null)
        {
            player.TakeDamage(1);

            Destroy(gameObject);
        }
    }
}
