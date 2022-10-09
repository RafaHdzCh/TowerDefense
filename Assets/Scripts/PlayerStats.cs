using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //Money
    public static int Money;
    [System.NonSerialized] public int startMoney = 350;

    //Lives
    public static int Lives;
    [System.NonSerialized] public int startLives = 20;
    

    private void Start()
    {
        Money = startMoney;
        Lives = startLives;
    }
}
