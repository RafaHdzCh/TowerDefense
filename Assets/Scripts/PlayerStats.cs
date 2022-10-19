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
    public int startLives = 3;

    public static int Rounds;
    

    private void Start()
    {
        Money = startMoney;
        Lives = startLives;
        Rounds = 0;
    }
}
