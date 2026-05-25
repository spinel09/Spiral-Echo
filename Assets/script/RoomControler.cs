using UnityEngine;

public class RoomControler : MonoBehaviour
{
    public GameObject[] enemies;

    public GameObject walls;

    private bool roomStarted = false;

    void Start()
    {
        walls.SetActive(false);

        foreach(GameObject enemy in enemies)
        {
            enemy.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(roomStarted)
        return;

        PlayerMovement player = 
        other.GetComponent<PlayerMovement>();

        if(player != null)
        {
            StartRoom();
        }
    }

    void StartRoom()
    {
        roomStarted = true;

        walls.SetActive(true);

        foreach(GameObject enemy in enemies)
        {
            enemy.SetActive(true);
        }
    }

    void Update()
    {
        if(!roomStarted)
        return;

        int alive = 0;

        foreach(GameObject enemy in enemies)
        {
            if(enemy != null)
            {
                alive ++;
            }
        }

        if(alive <= 0)
        {
            walls.SetActive(false);
        }
    }
}
