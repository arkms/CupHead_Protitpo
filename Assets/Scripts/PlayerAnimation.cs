using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator anim;

    public void Stand()
    {
        SetSpeed(0f);
        SetIsJumping(false);
    }

    public void SetSpeed(float v)
    {
        anim.SetFloat("velocidad", v);
    }

    public void SetIsJumping(bool v)
    {
        anim.SetBool("isJumping", v);
    }

    public void SetIsAgachado(bool v)
    {
        anim.SetBool("isAgachado", v);
    }

    public void Hit()
    {
        anim.SetTrigger("hit");
    }

    public void Win()
    {
        anim.SetTrigger("win");
    }

    public void SetIsShooting(bool v)
    {
        if (v)
        {
            anim.SetFloat("shooting", 1f);
        }
        else
        {
            anim.SetFloat("shooting", 0f);
        }
    }

}
