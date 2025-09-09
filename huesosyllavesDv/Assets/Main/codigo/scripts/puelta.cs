using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public TextMeshProUGUI mensajeUI;
    [SerializeField]
    GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager = gameManager;

            if (gameManager.TieneLlave)
            {
                //mensajeUI.text = "¡GANASTE!";
                //Time.timeScale = 0f; // Pausa el juego
                SceneManager.LoadScene("Ganaste");
            }
            else
            {
               // mensajeUI.text = "Necesitas la llave...";
            }
        }
    }
}
