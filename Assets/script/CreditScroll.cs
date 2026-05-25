using UnityEngine;

public class CreditScroll : MonoBehaviour
{
    public float speed = 50f;

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
