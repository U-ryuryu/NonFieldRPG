using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int hp;
    public int at;

    // 攻撃する
    public int Attack(EnemyManager enemy)
    {
        int damege = enemy.Damage(at);
        return damege;
    }
    // ダメージを受ける
    public int Damage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
        }
        return damage;
    }
}
