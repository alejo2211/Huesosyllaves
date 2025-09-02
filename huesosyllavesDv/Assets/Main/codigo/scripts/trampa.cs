using UnityEngine;

public class Trampa : MonoBehaviour
{
    public int da�o = -1; // Cu�nta vida resta

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().CambiarVida(da�o);
        }
    }
}
