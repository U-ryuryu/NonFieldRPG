using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    int currentStage = 0;  //現在のステージ進行度

// Nextボタンが押されたら
public void OnNextButton()
{
    currentStage++;
    Debug.Log("進行度増加"+ currentStage);
}
}
