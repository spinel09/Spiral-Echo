using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class EndDoor : MonoBehaviour
{
    public Image fadeScreen;

    public GameObject creditsPanel;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMovement player = 
        collision.gameObject.GetComponent<PlayerMovement>();

        if(player != null && player.hasKey)
        {
            StartCoroutine(EndGame(player));
        }
    }

    IEnumerator EndGame(PlayerMovement player)
    {
        player.canMove = false;

        Color color = fadeScreen.color;

        while(color.a < 1)
        {
            color.a += Time.deltaTime;

            fadeScreen.color = color;

            yield return null;
        }

        creditsPanel.SetActive(true);
    }
}
