using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //Money
    public static int Money;
    public int startMoney = 400;

    //Lives
    public static int Lives;
    public int startLives = 20;
    

    private void Start()
    {
        Money = startMoney;
        Lives = startLives;
    }
}
