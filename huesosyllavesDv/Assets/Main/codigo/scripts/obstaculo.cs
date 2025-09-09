using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    public int puntosNecesarios = 10; // Puntos que necesita el jugador para eliminar el obst�culo
    [SerializeField]
    private GameManager gameManager;

    private void Start()
    {
        // gameManager = FindObjectOfType<GameManager>();
        gameManager = gameManager;
    }

    private void Update()
    {
        if (gameManager != null && gameManager.puntos >= puntosNecesarios)
        {
            Destroy(gameObject); // El obst�culo desaparece
        }
    }
}
