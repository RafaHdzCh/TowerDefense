using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //Money
    public static int Money;
    [HideInInspector] public int startMoney = 350;

    //Lives
    public static int Lives;
    [HideInInspector] public int startLives = 20;

    public static int Rounds;
    

    private void Start()
    {
        Money = startMoney;
        Lives = startLives;
        Rounds = 0;
    }
}
