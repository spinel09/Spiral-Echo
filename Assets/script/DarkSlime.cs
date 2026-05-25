using UnityEngine;
using System.Collections;

public class DarkSlime : Enemy
{
    public GameObject attackPrefab;

    private Transform player;

    private bool canAttack = true;

    protected override void Start()
    {

        base.Start();

        player = 
        GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {

         if(!GameManager.instance.gameStarted)
        {
            return;
        }

        if(canAttack)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        canAttack = false;

        yield return new WaitForSeconds(1f);

        Vector2 offset =
        Random.insideUnitCircle * 1.5f;

        Instantiate(
            attackPrefab, 
            player.position,
            Quaternion.identity
        );

        yield return new WaitForSeconds(2f);

        canAttack = true;
    }

}
