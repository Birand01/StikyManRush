using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public delegate void OnBodyMovementHandler(Ray point);
    public static OnBodyMovementHandler OnBodyMove;

    private void Update()
    {
       
        OnBodyMovement();
    }

    public void OnBodyMovement()
    {
        OnBodyMove?.Invoke(GetMousePosition());
    }

    private Ray GetMousePosition()
    {
        Vector3 mousePos = Input.mousePosition;
        Ray mouseWorldPos = Camera.main.ScreenPointToRay(mousePos);
        return mouseWorldPos;
    }

}
