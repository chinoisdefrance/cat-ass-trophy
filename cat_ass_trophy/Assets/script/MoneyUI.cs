using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    public Text moneyText;

    //show Player's money
    void Update()
    {
        moneyText.text = PlayerStats.Money.ToString() + "Paws";
    }
}
