using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Al colocar este script sobre un objeto, puede ser dañado por el jugador
// Para que este script funcione, el objeto necesita tener asginado el tag de "Enemigo"

public class Daniable : MonoBehaviour
{

    public int hp;

    public UnityEvent OnDeath;

    public void RecibirDanio(int _cantidad)
    {
        hp -= _cantidad;
        if (hp <= 0)
        {
            OnDeath.Invoke(); // Avisale a todos los que estan subscritos
        }

    }



}
