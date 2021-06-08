using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// PlayerとEnemyの対戦の管理
public class BattleManager : MonoBehaviour
{
    public PlayerUIManager playerUI;
    public EnemyUIManager enemyUI;
    public PlayerManager player;
    public EnemyManager enemy;
    void Start()
    {
        player.Attack(enemy);
        enemyUI.UpdateUI(enemy);
        enemy.Attack(player);
        playerUI.UpdateUI(player);
    }
}
