using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ui_player : MonoBehaviour
{
    [Header("Carta")]
    public Image[] cartas; // [] => Es un arreglo, es decir, son varios.

    [Header("Vidas")]
    public TextMeshProUGUI vidasTxt;

    //TextMeshProUGUI txt1; // UI
    //TextMeshPro txt2; // Como 3D

    public void ActualizarVidas(int _vidas)
    {
        vidasTxt.SetText(_vidas.ToString());      // vidasTxt.text = _vidas.ToString()
    }


    public void ActualizarCartas(float _valor) // [0f, 5f]
    {
        // 3.5   => 3 cartas completas y la 4° esta al 0.5

        int cartasCompletas = Mathf.FloorToInt(_valor); // Redondea hacia abajo    =>  3
        float cartaIncompleta = _valor - cartasCompletas; // 3.5 - 3 => 0.5

        // Todas las apagamoss
        foreach (Image c in cartas) // Recorre 1 por 1, del arreglo de cartas
        {
            c.fillAmount = 0f;
        }

        // Rellenamos las cartas que estan completas
        for (int i = 0; i < cartasCompletas; i++)
        {
            cartas[i].fillAmount = 1f;
        }

        // Rellenamos hasta se pueda de la incompleta
        if (cartasCompletas < cartas.Length) // Hay aun hay carta que podamos rellenar con un porcentaje?
        {
            cartas[cartasCompletas].fillAmount = cartaIncompleta;
        }
    }


}
