using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

// PlayerとEnemyの対戦の管理
public class BattleManager : MonoBehaviour
{
    public Transform playerDamagePanel;
    public QuestManager questManager;
    public PlayerUIManager playerUI;
    public EnemyUIManager enemyUI;
    public PlayerManager player;
    public EnemyManager enemy;

    private void Start()
    {
        enemyUI.gameObject.SetActive(false);
    }

    // 初期設定
    public void Setup(EnemyManager enemyManager)
    {
        SoundManager.instance.PlayBGM("Battle");
        enemyUI.gameObject.SetActive(true);
        enemy = enemyManager;
        enemyUI.SetupUI(enemy);
        playerUI.SetupUI(player);

        enemy.AddEventListenerOnTap(PlayerAttack);
    }

    void PlayerAttack()
    {
        StopAllCoroutines();
        SoundManager.instance.PlaySE(1);
        player.Attack(enemy);
        enemyUI.UpdateUI(enemy);
        if (enemy.hp == 0)
        {
            enemyUI.gameObject.SetActive(false);
            Destroy(enemy.gameObject);
            EndBattle();
        }
        else
        {
            StartCoroutine(EnemyTurn());
        }
    }

    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(1f);
        SoundManager.instance.PlaySE(1);
        playerDamagePanel.DOShakePosition(0.3f, 0.5f ,20, 0, false, true);
        enemy.Attack(player);
        playerUI.UpdateUI(player);
    }

    void EndBattle()
    {
        SoundManager.instance.PlayBGM("Quest");
        questManager.EndBattle();
    }
}
