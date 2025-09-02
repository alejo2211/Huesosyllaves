using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    public int puntosNecesarios = 10; // Puntos que necesita el jugador para eliminar el obst�culo
    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (gameManager != null && gameManager.puntos >= puntosNecesarios)
        {
            Destroy(gameObject); // El obst�culo desaparece
        }
    }
}
