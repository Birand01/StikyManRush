using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private void Awake()
    {
        PlayerMovement.OnPlayerMove += PlayerMovementAnimationn;
        anim = GetComponent<Animator>();
    }
    public void PlayerMovementAnimationn(float value)
    {
        anim.SetFloat("Motion", value);
    }

    private void OnDestroy()
    {
        PlayerMovement.OnPlayerMove -= PlayerMovementAnimationn;
    }
}
