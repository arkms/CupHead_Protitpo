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


    void Update()
    {
        Disparar();
        DispararExMove();
    }

    void Disparar()
    {
        disparoCooldown -= Time.deltaTime;
        if (disparoCooldown > 0f) return; // Todavia esta en cooldown el disparo, nos salimos.

        if (Input.GetMouseButton(0)) // Esta siendo presionado click izquierdo?
        {
            GameObject bala = Instantiate(prefabBala, spawnPoint.position, spawnPoint.rotation);
            float dir = transform.localScale.x;
            bala.GetComponent<Rigidbody2D>().AddForce(Vector2.right * dir * velocidadBala, ForceMode2D.Impulse); // Empujar bala
            disparoCooldown = frecuenciaDisparo;
        }
    }

    void DispararExMove() // Super tiro
    {
        if (Input.GetMouseButtonDown(1)) // click derecho
        {
            if (meterCard >= 1f)
            {
                GameObject bala = Instantiate(prefabExMove, spawnPoint.position, spawnPoint.rotation);
                float dir = transform.localScale.x;
                bala.GetComponent<Rigidbody2D>().AddForce(Vector2.right * dir * velocidadBala, ForceMode2D.Impulse); // Empujar bala

                meterCard -= 1f;
            }
        }
    }


    public void AumentarMeterCard(float _cantidad)
    {
        meterCard += _cantidad; // meterCard = meterCard + _cantidad
        if (meterCard > 5f) // No puede ser mayor a 5
            meterCard = 5f;
    }

    void ConsumirMeterCard(float _cantidad)
    {
        meterCard -= _cantidad;
        if(meterCard < 0f)
            meterCard = 0f;
    }

}
