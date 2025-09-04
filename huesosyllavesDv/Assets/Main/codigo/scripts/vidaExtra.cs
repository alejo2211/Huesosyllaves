using UnityEngine;

public class VidaExtra : MonoBehaviour
{
    
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager.vida++;
            Destroy(gameObject);
        }
    }
}
