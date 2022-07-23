using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaPlayer : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 5f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        if (collision.CompareTag("Enemigo"))
        {
            collision.attachedRigidbody.GetComponent<Daniable>().RecibirDanio(1);
        }

    }
}
