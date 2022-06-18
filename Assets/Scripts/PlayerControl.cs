using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float velocidad;
    public Rigidbody2D rigi;
    public CapsuleCollider2D capsuleCollider;
    public int unaVariable;

    [Header("Salto")]
    public float velocidadSalto;
    public Transform sueloCheck;
    public float sueloCheckRadio;
    public LayerMask suelomask;

    [Header("Dash")] 
    public float dashVelocidad;
    public float dashDuracion;
    bool EstaEnDash = false;

    // Parry
    bool EstaTocandoObjetoParry = false;
    GameObject parryGo;

    // Agachado
    Vector2 ColliderOffsetPie = new Vector2(0f, 0f);
    Vector2 ColliderSizePie = new Vector2(1f, 2f);
    Vector2 ColliderOffsetAgachado = new Vector2(0f, -0.5f);
    Vector2 ColliderSizeAgachado = new Vector2(1f, 1f);

    void Start()
    {
    }

    void FixedUpdate()
    {
        Movimiento();
        Agachar();
    }

    void Update()
    {
        Saltar();
        Dash();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Parry"))
        {
            EstaTocandoObjetoParry = true;
            parryGo = collision.gameObject; // Guardamos que objeto estamos tocando
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Parry"))
        {
            EstaTocandoObjetoParry = false;
            parryGo = null;
        }
    }

    void Movimiento()
    {
        if (EstaEnDash) return;

        float h = Input.GetAxisRaw("Horizontal"); // A, D, flecha izquierda, flecha derecha, joystick derecho
        Vector2 vel = rigi.velocity; // Lo hacemos sin addForce porque no queremos inersia
        vel.x = h * velocidad;
        rigi.velocity = vel;

        // Giramos al personaje hacia la direción que estamos caminando
        Vector3 escala = transform.localScale;
        if (h > 0f) // derecha
        {
            escala.x = 1f;
        }
        else if (h < 0f) // izquierda
        {
            escala.x = -1f;
        }

        transform.localScale = escala;
    }

    void Agachar()
    {
        float v = Input.GetAxisRaw("Vertical");
        if (v < 0f) // Estoy tratando de agachar
        {
            capsuleCollider.offset = ColliderOffsetAgachado;
            capsuleCollider.size = ColliderSizeAgachado;
        }
        else // Estoy de pie
        {
            capsuleCollider.offset = ColliderOffsetPie;
            capsuleCollider.size = ColliderSizePie;
        }
    }

    void Saltar()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bool EstaTocandoSuelo = Physics2D.OverlapCircle(sueloCheck.position, sueloCheckRadio, suelomask);
            if (EstaTocandoSuelo || EstaTocandoObjetoParry) //  OR => ||
            {
                Vector2 vel = rigi.velocity;
                vel.y = velocidadSalto;
                rigi.velocity = vel;

                if (parryGo) // Tenemos un objeto parry?
                {
                    Destroy(parryGo);
                }
            }
        }
    }

    void Dash()
    {
        if ( Input.GetKeyDown(KeyCode.LeftShift) && EstaEnDash == false )
        {
            //Hacia donde estamos mirando?
            float dir = transform.localScale.x; // La escala en X, nos indica hacia donde mira ( + derecha, - izquierda )

            rigi.gravityScale = 0f; // En el dash, la gravedad no funciona
            rigi.velocity = Vector2.zero;
            rigi.AddForce(Vector2.right * dir * dashVelocidad, ForceMode2D.Impulse);
            EstaEnDash = true; // Esto ayuda a que el Movimiento no funcione mientras estoy en el dash
            Invoke(nameof(ApagarDash), dashDuracion);
        }
    }

    void ApagarDash()
    {
        EstaEnDash = false;
        rigi.gravityScale = 1f;
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(sueloCheck.position, sueloCheckRadio);
    }
}
