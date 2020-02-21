using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TurretBluePrint
{
    public GameObject prefabs;
    public int cost;
    public Text button;
    public bool isTurret = true;

    //show turrets prices
    public void Init()
    {
        button.text = cost + " Paws";
    }
}
