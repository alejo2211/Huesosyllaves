using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private bool isPaused = false;
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private Image[] spritesCorazon;

    

   


    void Update()
    {
        

        // Detectar cuando se presiona la tecla Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        panel.SetActive(true);
        Time.timeScale = 0f; // Detiene el tiempo del juego
        isPaused = true;

        // Aquí puedes activar tu menú de pausa si tienes uno
        // Ejemplo: pauseMenuUI.SetActive(true);
    }

    void ResumeGame()
    {
        panel.SetActive(false);
        Time.timeScale = 1f; // Reanuda el tiempo del juego
        isPaused = false;
        // Aquí puedes desactivar el menú de pausa
        // Ejemplo: pauseMenuUI.SetActive(false);
    }

    void ActualizarUIVida()
    {
        for (int i = 0; i < spritesCorazon.Length; i++)
        {
            if (i < 5)
            {
                spritesCorazon[i].enabled = true;  // Muestra el corazón
            }
            else
            {
                spritesCorazon[i].enabled = false; // Oculta el corazón
            }
        }
    }
}
