using UnityEngine;

public class TiempoExtra : MonoBehaviour
{
    public float cantidad = 10f; // Segundos que suma

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FindObjectOfType<GameManager>().SumarTiempo(cantidad);
            Destroy(gameObject);
        }
    }
}
