using UnityEngine;

public class GameManager : MonoBehaviour
{

    public bool gameStarted = false;
    public static GameManager instance;

    public int slimesAlive;

    public GameObject key;

    void Awake()
    {
        instance = this;
    }

    public void SlimeKilled()
    {
        slimesAlive--;

        Debug.Log("Slimes left : " + slimesAlive);

        if(slimesAlive <= 0)
        {
            key.SetActive(true);
        }
    }
}
