using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// StageUI(ステージ数のUI/進行ボタン/街に戻るボタン)の管理
public class StageUIManager : MonoBehaviour
{
    public Text stageText;

    public void UpdateUI(int currentStage)
    {
        stageText.text = string.Format("ステージ：{0}", currentStage + 1);
    }
}
