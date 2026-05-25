using UnityEngine;

public class safeZone : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other)
    {
        PlayerMovement player = 
        other.GetComponent<PlayerMovement>();

        if(player != null)
        {
            GameManager.instance.gameStarted = true;

            gameObject.SetActive(false);
        }
    }
}
