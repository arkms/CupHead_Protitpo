using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton

    Vector3 posicionInicialJugador;

    public int vidas = 3;
    public ui_player uiPlayer;

    void Awake()
    {
        Instance = this;
        posicionInicialJugador = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    public void JugadorMuere()
    {
        vidas--; // vidas = vidas - 1;
        if (vidas < 0)
        {
            // El jugador ya no tiene más vidas!
            vidas = 0;
            // SceneManager.LoadScene("SampleScene");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // <= Reiniciar nivel
        }
        else // AUn tiene vidas
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = posicionInicialJugador;
        }

        uiPlayer.ActualizarVidas(vidas);
    }

    public void AgregarVida()
    {
        vidas++; // vidas = vidas + 1
        uiPlayer.ActualizarVidas(vidas);
    }
}
