using UnityEngine;

public class EndScene : MonoBehaviour
{
    public PlayerMovement player;

    void Start()
    {
        player.canMove = false;
    }
}
