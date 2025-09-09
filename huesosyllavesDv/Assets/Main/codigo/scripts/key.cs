using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField]
    private bool TieneLlave = false;
    [SerializeField]
    private GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Indica en el GameManager que ya tenemos la llave
           // FindObjectOfType<GameManager>().TieneLlave = true;
            gameManager.TieneLlave = true;

            // Destruye la llave del escenario
            Destroy(gameObject);
        }
    }
}
