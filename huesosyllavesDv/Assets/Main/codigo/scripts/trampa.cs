using UnityEngine;

public class Trampa : MonoBehaviour
{
    public int daño = -1; // Cuánta vida resta

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().CambiarVida(daño);
        }
    }
}
