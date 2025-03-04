using UnityEngine;

public class Ator : MonoBehaviour
{
    public float verticalSpeed = 5f;

    void Update()
    {
        float moveVertical = Input.GetAxis("Vertical") * verticalSpeed * Time.deltaTime;
        transform.Translate(0, moveVertical, 0); // Movimento apenas no eixo Y
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Residuos"))
        {
            //Debug.Log("Coletou resíduo");
            ScoreManager.instance.AddPoint();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Peixes"))
        {
            //Debug.Log("Colidiu com um peixe");
            GameManager.instance.GameOver();
        }
    }
}
