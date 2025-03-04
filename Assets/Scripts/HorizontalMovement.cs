using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    private float speed = 2.0f;

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Destrói os objetos quando saem da tela
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}