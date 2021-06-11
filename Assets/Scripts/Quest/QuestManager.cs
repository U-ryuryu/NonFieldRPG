using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class QuestManager : MonoBehaviour
{
    public StageUIManager stageUI;
    public GameObject enemyPrefab;
    public BattleManager battleManager;
    public SceneTransitionManager sceneTransitionManager;
    public GameObject questBG;

    // 敵に遭遇するテーブル：-1なら遭遇しない、0なら遭遇
    int[] encountTable = {-1, -1, 0, -1, 0, -1};
    int currentStage = 0;  //現在のステージ進行度

    private void Start()
    {
        stageUI.UpdateUI(currentStage);
        DialogTextManager.instance.SetScenarios(new string[] {"森についた。"});
    }

    IEnumerator Searching()
    {
        DialogTextManager.instance.SetScenarios(new string[] {"探索中..."});
        // 背景を大きく
        questBG.transform.DOScale(new Vector3(1.5f, 1.5f, 1.5f), 2f).OnComplete(() => questBG.transform.localScale = new Vector3(1, 1, 1));
        // フェードアウト
        SpriteRenderer questBGSpriteRenderer = questBG.GetComponent<SpriteRenderer>();
        questBGSpriteRenderer.DOFade(0, 2f).OnComplete(() => questBGSpriteRenderer.DOFade(1, 0));
        
        yield return new WaitForSeconds(2f);

        currentStage++;
        // 進行度をUIに反映
        stageUI.UpdateUI(currentStage);
        
        if (encountTable.Length <= currentStage)
        {
            Debug.Log("クエストクリア");
            QuestClear();
        }
        else if (encountTable[currentStage] == 0 )
        {
            EncountEnemy();
        }
        else
        {
            stageUI.ShowButtons();
        }
    }
// Nextボタンが押されたら
    public void OnNextButton()
    {
        SoundManager.instance.PlaySE(0);
        stageUI.HideButtons();
        StartCoroutine(Searching());
    }

    public void OnToTownButton()
    {
        SoundManager.instance.PlaySE(0);
    }

    void EncountEnemy()
    {
        DialogTextManager.instance.SetScenarios(new string[] {"モンスターに遭遇した！"});
        stageUI.HideButtons();
        GameObject enemyObj = Instantiate(enemyPrefab);
        EnemyManager enemy = enemyObj.GetComponent<EnemyManager>();
        battleManager.Setup(enemy);
    }

    public void EndBattle()
    {
        stageUI.ShowButtons();
    }

    void QuestClear()
    {
        DialogTextManager.instance.SetScenarios(new string[] {"宝箱を手に入れた。\n街に戻りましょう。"});
        SoundManager.instance.StopBGM();
        SoundManager.instance.PlaySE(2);
        stageUI.ShowClearText();
        // sceneTransitionManager.LoadTo("Town");
    }

    public void PlayerDeath()
    {
        sceneTransitionManager.LoadTo("Town");
    }

}
