using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

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

    private void Start()
    {
        tiempoRestante = tiempoInicial;
        ActualizarUI();
    }

    private void Update()
    {
        // Reducir el tiempo cada frame
        tiempoRestante -= Time.deltaTime;

        if (tiempoRestante <= 0)
        {
            // Reinicia la escena si se acaba el tiempo
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        ActualizarUI();
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
            SceneManager.LoadScene("Perdiste");
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

    private void ActualizarUI()
    {
        
        if (puntosUI != null) puntosUI.text = "Puntos: " + puntos;
        if (vidaUI != null) vidaUI.text = "Vida: " + vida;
        if (llaveUI != null) llaveUI.text = "Llave: " + (TieneLlave ? "Sí" : "No");
        if (tiempoUI != null) tiempoUI.text = "Tiempo: " + Mathf.Ceil(tiempoRestante);
    }
}
