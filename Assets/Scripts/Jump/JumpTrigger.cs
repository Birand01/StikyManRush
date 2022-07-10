using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    public delegate void OnJumpMovementStartHandler();
    public static event OnJumpMovementStartHandler OnJumpMoveStart;

    public delegate void OnJumpMovemenEndHandler();
    public static event OnJumpMovemenEndHandler OnJumpMoveEnd;
    private enum TriggerState
    {
        JumpStart,JumpEnd
    }
    [SerializeField] TriggerState triggerState;

    private void OnTriggerEnter(Collider other)
    {
        switch (triggerState)
        {
            case TriggerState.JumpStart:
                OnJumpMoveStart?.Invoke();
                break;
            case TriggerState.JumpEnd:
                OnJumpMoveEnd?.Invoke();
                break;
            default:
                break;
        }
    }
}
