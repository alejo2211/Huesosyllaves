using UnityEngine;

public class VidaExtra : MonoBehaviour
{
    public int cantidad = 1; // Cuánta vida suma

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().CambiarVida(cantidad);
            Destroy(gameObject);
        }
    }
}
