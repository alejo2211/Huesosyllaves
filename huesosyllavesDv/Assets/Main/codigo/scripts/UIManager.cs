using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private bool isPaused = false;
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private Sprite[] spritesCorazon;
    [SerializeField]
    private Image imCorazones;
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

    public void ActualizarUIVida(int vidaActual)
    {
        if (imCorazones != null && vidaActual >= 0 && vidaActual < spritesCorazon.Length)
        {
            imCorazones.sprite = spritesCorazon[vidaActual];
        }
        else
        {
            Debug.LogError("No esta en el rango o la imagen no esta asiganda");
        }
    }
}
