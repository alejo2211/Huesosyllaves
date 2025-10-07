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
    [SerializeField]
    private Color conllave;
    [SerializeField]
    private Color sinllave;
    [SerializeField]
    private Image imLlave;
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

  
    }

    void ResumeGame()
    {
        panel.SetActive(false);
        Time.timeScale = 1f; // Reanuda el tiempo del juego
        isPaused = false;

    }

    public void CambiarLlave(bool t)
    {
        imLlave.color = t ? conllave : sinllave;
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
