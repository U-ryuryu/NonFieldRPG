using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public StageUIManager stageUI;
    int currentStage = 0;  //現在のステージ進行度

    private void Start()
    {
        stageUI.UpdateUI(currentStage);
    }
// Nextボタンが押されたら
    public void OnNextButton()
    {
        currentStage++;
        Debug.Log("進行度増加"+ currentStage);
        // 進行度をUIに反映
        stageUI.UpdateUI(currentStage);
    }
}
