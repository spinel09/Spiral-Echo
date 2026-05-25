using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{


public Slider healthSlider;
    public bool isInvincible = false;
    public int health = 3;



    void Start()
    {
        healthSlider.maxValue = 4;
        healthSlider.value = health;
    }



    public void TakeDamage(int damage)
    {
        if(isInvincible)
        return; 


        health -= damage;

        healthSlider.value = health;

        Debug.Log("HP : " + health);

        if(health <= 0)
        {
            Die();
        }

        StartCoroutine(Invincibility());
    }

    void Die()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().buildIndex
        );
    }

    IEnumerator Invincibility()
    {
        isInvincible = true;

        yield return new WaitForSeconds(1f);
        isInvincible = false;
    }
}
