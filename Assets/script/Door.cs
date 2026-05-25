using UnityEngine.SceneManagement;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject Player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMovement pm = collision.gameObject.GetComponent<PlayerMovement>();

        if(pm != null && pm.hasKey)
        {
            Debug.Log("Porte Ouverte ");

            

            SceneManager.LoadScene("scene2");
        }
    }
}
