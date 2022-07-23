using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
