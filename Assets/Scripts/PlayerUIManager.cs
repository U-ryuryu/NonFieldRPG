using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    public Text hpText;
    public Text atText;

    public void UpdateUI()
    {
        hpText.text = string.Format("HP：{0}", 80);
        atText.text = string.Format("AT：{0}", 10);
    }
}
