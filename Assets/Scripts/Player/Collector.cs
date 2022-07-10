using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    public delegate void OnDiamondCollectHandler(int value);
    public static event OnDiamondCollectHandler OnDiamondCollect;

    public int CoinCount { get; private set; } = 0;
    public void AddCoin(int numberOfCoins)
    {
        CoinCount += numberOfCoins;
        OnDiamondCollect.Invoke(CoinCount);
    }
}
