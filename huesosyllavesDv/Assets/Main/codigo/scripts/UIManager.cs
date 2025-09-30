using UnityEngine;

public class UIManager : MonoBehaviour
{
    private bool isPaused = false;

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
        Time.timeScale = 0f; // Detiene el tiempo del juego
        isPaused = true;
        // Aquí puedes activar tu menú de pausa si tienes uno
        // Ejemplo: pauseMenuUI.SetActive(true);
    }

    void ResumeGame()
    {
        Time.timeScale = 1f; // Reanuda el tiempo del juego
        isPaused = false;
        // Aquí puedes desactivar el menú de pausa
        // Ejemplo: pauseMenuUI.SetActive(false);
    }
}
