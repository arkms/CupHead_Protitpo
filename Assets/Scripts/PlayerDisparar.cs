using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDisparar : MonoBehaviour
{
    public GameObject prefabBala;
    public Transform spawnPoint;
    public float velocidadBala;
    public float frecuenciaDisparo;
    float disparoCooldown;

    [Header("SuperMeterCard")] 
    public float meterCard; // [0, 5]
    public GameObject prefabExMove;
    public float frecuenciaExMove;
    float ExMoveCooldown;
    public ui_player uiPlayer;

    public PlayerAnimation playerAnimation;

    void Start()
    {
        uiPlayer.ActualizarCartas(meterCard);
    }

    void Update()
    {
        Disparar();
        DispararExMove();
    }

    void Disparar()
    {
        disparoCooldown -= Time.deltaTime;
        
        if (Input.GetMouseButton(0)) // Esta siendo presionado click izquierdo?
        {
            playerAnimation.SetIsShooting(true);

            if (disparoCooldown < 0f)
            {
                GameObject bala = Instantiate(prefabBala, spawnPoint.position, spawnPoint.rotation);
                float dir = transform.localScale.x;
                bala.GetComponent<Rigidbody2D>().AddForce(Vector2.right * dir * velocidadBala, ForceMode2D.Impulse); // Empujar bala
                disparoCooldown = frecuenciaDisparo;
            }
        }
        else
        {
            playerAnimation.SetIsShooting(false);
        }
    }

    void DispararExMove() // Super tiro
    {
        ExMoveCooldown -= Time.deltaTime; // ExMoveCooldown = ExMoveCooldown - Time.deltaTime;
        if (ExMoveCooldown > 0f) return; // Aun esta en cooldown, nos salimos de la función

        if (Input.GetMouseButtonDown(1)) // click derecho
        {
            if (meterCard >= 1f)
            {
                GameObject bala = Instantiate(prefabExMove, spawnPoint.position, spawnPoint.rotation);
                float dir = transform.localScale.x;
                bala.GetComponent<Rigidbody2D>().AddForce(Vector2.right * dir * velocidadBala, ForceMode2D.Impulse); // Empujar bala

                ConsumirMeterCard(1f); // meterCard -= 1f;
                ExMoveCooldown = frecuenciaExMove;
            }
        }
    }


    public void AumentarMeterCard(float _cantidad)
    {
        meterCard += _cantidad; // meterCard = meterCard + _cantidad
        if (meterCard > 5f) // No puede ser mayor a 5
            meterCard = 5f;
        uiPlayer.ActualizarCartas(meterCard);
    }

    void ConsumirMeterCard(float _cantidad)
    {
        meterCard -= _cantidad;
        if(meterCard < 0f)
            meterCard = 0f;
        uiPlayer.ActualizarCartas(meterCard);
    }

}
