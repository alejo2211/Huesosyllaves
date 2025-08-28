using UnityEngine;
using TMPro;  

public class ScoreManager : MonoBehaviour
{
    public int puntos = 0;          
    public TextMeshProUGUI puntosUI; 
    public GameObject obstaculo;     

    public void SumarPunto()
    {
        puntos++;
        puntosUI.text = "Puntos: " + puntos;

      
        if (puntos >= 10 && obstaculo != null)
        {
            Destroy(obstaculo);
        }
    }
}


