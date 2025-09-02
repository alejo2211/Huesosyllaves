using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public TextMeshProUGUI mensajeUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager manager = FindObjectOfType<GameManager>();

            if (manager.TieneLlave)
            {
                mensajeUI.text = "¡GANASTE!";
                Time.timeScale = 0f; // Pausa el juego
            }
            else
            {
                mensajeUI.text = "Necesitas la llave...";
            }
        }
    }
}
