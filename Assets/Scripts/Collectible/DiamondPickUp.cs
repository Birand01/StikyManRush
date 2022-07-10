using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondPickUp : PickUp
{
    [SerializeField] int _coinValue = 1;
    [SerializeField] float rotationSpeed;
    private void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
    }
    protected override void OnPickUp(Collector player)
    {
        player.AddCoin(_coinValue);
    }

  
}
