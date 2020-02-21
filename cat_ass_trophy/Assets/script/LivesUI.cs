using UnityEngine.UI;
using UnityEngine;

public class LivesUI : MonoBehaviour
{
    public Text livesText;

    //show Player's lives
    void Update()
    {
        livesText.text = PlayerStats.Lives.ToString() + " CARDBOARDS";

        
    }
}
