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


    public GameObject textDisplay;
    public Transform parent;
    //Player's money and lives
    void Start()
    {
        instance = this;
        Money = startMoney;
        Lives = startLives;
        sndController = GetComponent<SoundController>();
    }

    //when Player builds a turret, his money decreases and it makes a sound
    public static void DecreaseMoney(int cost)
    {

        PlayerStats.Money -= cost;
        PlayerStats.instance.sndController.PlaySound(PlayerStats.instance.cashMachine);
    }

    //Player can lost lives, if his number of lives are equal or lower to zero it's Game Over, damage depends of ennemy type 
    public static void DecreaseLive(int damage)
    {
        PlayerStats.Lives -= damage;

        if (PlayerStats.instance.parent)
        {
            var go = Instantiate(
                PlayerStats.instance.textDisplay, 
                PlayerStats.instance.parent.position, 
                Quaternion.Euler(0, -90, 0));
            go.GetComponentInChildren<TextMesh>().text = damage.ToString();
        }
        if (PlayerStats.Lives <= 0)
            PlayerStats.instance.gameOver.Invoke();
    }
}
