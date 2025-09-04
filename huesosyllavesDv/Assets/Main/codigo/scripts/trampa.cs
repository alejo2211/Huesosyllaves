using UnityEngine;

public class Trampa : MonoBehaviour
{
public GameManager gameManager;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            gameManager.vida--;
            Debug.Log("entrando a la trampa");
            gameManager.Perder();
        }
    }
}
