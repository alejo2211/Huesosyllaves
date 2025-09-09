using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [Header("Puntos")]
    public int puntos = 1;
    public TextMeshProUGUI puntosUI;
    public GameObject obstaculo;

    [Header("Llave")]
    public bool TieneLlave = false;
    public TextMeshProUGUI llaveUI;

    [Header("Vida")]
    public int vida = 3;
    public TextMeshProUGUI vidaUI;

    [Header("Tiempo")]
    public float tiempoInicial = 60f;
    private float tiempoRestante;
    public TextMeshProUGUI tiempoUI;
    private bool juegoIniciado = false; // Para controlar cuándo empieza el conteo

    [Header("Mensajes")]
    [SerializeField] private TextMeshProUGUI mensajeUI;
    [TextArea(3, 5)]
    public string mensajeTutorial = "¡Bienvenido!\n\nUsa WASD o las flechas para moverte.\n" +
                                    "Objetivo: recoge la llave y llega a la salida.\n" +
                                    "Cuidado con los obstáculos, te quitan vida.";

    [SerializeField] private int puntosnecesarios;

    private void Start()
    {
        tiempoRestante = tiempoInicial;
        ActualizarUI();
        StartCoroutine(MostrarMensajeTutorial());
    }

    private void Update()
    {
        if (!juegoIniciado) return; // No empieza el conteo hasta terminar tutorial

        // Reducir el tiempo cada frame
        tiempoRestante -= Time.deltaTime;

        if (tiempoRestante <= 0)
        {
            // Reinicia la escena si se acaba el tiempo
            SceneManager.LoadScene("Taller");
        }

        ActualizarUI();
    }

    IEnumerator MostrarMensajeTutorial()
    {
        if (mensajeUI != null)
        {
            mensajeUI.text = mensajeTutorial;
            mensajeUI.gameObject.SetActive(true);
        }

        yield return new WaitForSeconds(5f); // Espera 5 segundos

        if (mensajeUI != null)
        {
            mensajeUI.text = ""; // Borra el mensaje
            mensajeUI.gameObject.SetActive(false);
        }

        juegoIniciado = true; // Ahora sí arranca el tiempo
    }

    public void SumarVida()
    {
        vida++;
        ActualizarUI();
    }

    public void RestarVida()
    {
        vida--;
        ActualizarUI();
    }

    public void SumarPunto()
    {
        puntos++;
        if (puntos >= 10 && obstaculo != null)
        {
            Destroy(obstaculo);
        }
        ActualizarUI();
    }

    public void Perder()
    {
        if (vida <= 0)
        {
            SceneManager.LoadScene("Taller");
        }
        ActualizarUI();
    }

    public void RecogerLlave()
    {
        TieneLlave = true;
        ActualizarUI();
    }

    public void SumarTiempo(float cantidad)
    {
        tiempoRestante += cantidad;
        ActualizarUI();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TieneLlave = true;
            if (mensajeUI != null)
            {
                mensajeUI.gameObject.SetActive(true);
                mensajeUI.text = "¡Ganaste!";
            }
        }
    }

    public void DestruirObstaculo()
    {
        if (puntos >= puntosnecesarios)
        {
            Destroy(gameObject); // El obstáculo desaparece
        }
    }

    private void ActualizarUI()
    {
        if (puntosUI != null) puntosUI.text = "Puntos: " + puntos;
        if (vidaUI != null) vidaUI.text = "Vida: " + vida;
        if (llaveUI != null) llaveUI.text = "Llave: " + (TieneLlave ? "Sí" : "No");
        if (tiempoUI != null) tiempoUI.text = "Tiempo: " + Mathf.Ceil(tiempoRestante);
    }
}
