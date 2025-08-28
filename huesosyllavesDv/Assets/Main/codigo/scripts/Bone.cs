using UnityEngine;

public class Bone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Si el jugador lo toca
        {
            // Busca el ScoreManager en la escena y suma punto
            FindObjectOfType<ScoreManager>().SumarPunto();

            // Destruye el hueso recogido
            Destroy(gameObject);
        }
    }
}
 