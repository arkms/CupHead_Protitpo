using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton

    Vector3 posicionInicialJugador;

    public int vidas = 3;
    public int monedas = 0;
    public ui_player uiPlayer;
    public PlayerControl playerControl;

    void Awake()
    {
        Instance = this;
        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        posicionInicialJugador = GameObject.FindGameObjectWithTag("Player").transform.position;  // playerControl.transform.position;
    }

    public void AgregarMoneda()
    {
        monedas++; // monedas = monedas + 1
        uiPlayer.ActualizarMonedas(monedas);
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

        playerControl.Danio();
        uiPlayer.ActualizarVidas(vidas);
    }

    public void AgregarVida()
    {
        vidas++; // vidas = vidas + 1
        uiPlayer.ActualizarVidas(vidas);
    }

    [ContextMenu("Nivel completado")]
    public void NivelCompletado()
    {
        playerControl.enabled = false; // desactivamo script
        playerControl.GetComponent<PlayerAnimation>().Win();
        playerControl.GetComponent<PlayerDisparar>().enabled = false; // Ya no puede disparar

        Invoke(nameof(CargarSiguienteNivel), 3f);
    }

    void CargarSiguienteNivel()
    {
        print("Aqui cargar otro nivel");
    }

}
