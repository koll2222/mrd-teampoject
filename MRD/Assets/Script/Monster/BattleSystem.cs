using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface IBattle
{
    bool isLive { get; }
}
public class BattleSystem : MonsterProperty
{
    public void TakeDamage(float dmg)
    {
        CurHp -= dmg;
        Debug.Log(dmg);
        if (CurHp <= 0)
        {
            m_deathAlarm?.Invoke();
            myAnim.SetTrigger("Death");
            GameManager.Instance.Gold(1);
            GameManager.Instance.KillScore(1);
            GameManager.Instance.Enemys(-1);
        }
    }
}
