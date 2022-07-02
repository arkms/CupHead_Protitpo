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

}
