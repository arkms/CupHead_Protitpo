using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=eD6cXU2G-tk
public class GoopyIA : MonoBehaviour
{

    [Header("Fase 1")] 
    public float fuerzaSaltoMin;
    public float fuerzaSaltoMax;
    float saltoDirrecion = -1f; // Empieza hacia izquierda
    public float saltoCooldown;

    [Header("Referencias")]
    public Rigidbody2D rigi;
    public Animator anim;
    public SpriteRenderer dibujo;

    void Start()
    {

    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Pared"))
        {
            saltoDirrecion *= -1f; // saltoDirrecion = saltoDirrecion * -1f; // Invertimos signo ( - , + )
            dibujo.flipX = saltoDirrecion > 0f;
        }

        if (collision.collider.CompareTag("Suelo"))
        {
            PreSalto();
        }
    }

    void PreSalto()
    {
        anim.SetTrigger("Saltar");
        //Invoke(nameof(Saltar), saltoCooldown);
    }

    [ContextMenu("Saltar")]
    public void Saltar()
    {
        float fuerzaSalto = Random.Range(fuerzaSaltoMin, fuerzaSaltoMax);
        Vector2 dir = new Vector2(0.2f * saltoDirrecion, 0.7f);
        rigi.AddForce(dir * fuerzaSalto);
    }

    public void VidaLlego0()
    {
        Destroy(gameObject);
    }
}
