using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 400;

    public static int Lives;
    public int startLives = 20;
    public static PlayerStats instance;
    public SoundController sndController;
    public AudioClip cashMachine;
    public UnityEvent gameOver;

    void Start()
    {
        instance = this;
        Money = startMoney;
        Lives = startLives;
        sndController = GetComponent<SoundController>();
    }


    public static void DecreaseMoney(int cost)
    {

        PlayerStats.Money -= cost;
        PlayerStats.instance.sndController.PlaySound(PlayerStats.instance.cashMachine);
    }

    public static void DecreaseLive()
    {
        PlayerStats.Lives--;
        
        if(PlayerStats.Lives <= 0)
            PlayerStats.instance.gameOver.Invoke();
    }
}
