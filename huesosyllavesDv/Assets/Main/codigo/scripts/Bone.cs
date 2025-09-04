using UnityEngine;

public class Bone : MonoBehaviour
{
    public GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Si el jugador lo toca
        {
            gameManager.puntos++;
            Destroy(gameObject);
        }
    }
}
 