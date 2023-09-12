using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Monster m_mons;
    bool m_bossPattern1 = false;
    bool m_bossPattern2 = false;
    Rigidbody2D rigi;
    public Transform m_skillPos;
    public LayerMask m_playerMask;
    void Start()
    {
        m_mons = GetComponent<Monster>();
        rigi = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        if(!m_bossPattern1 && m_mons.CurHp <= 750)
        {
            Pattern1();
            m_bossPattern1 = true;
        }

        if(!m_bossPattern2 && m_mons.CurHp <= 300)
        {
            Pattern2();
            m_bossPattern2 = true;
        }
        bossSkill1();
    }
    void Pattern1()
    {
        //StartCoroutine(BossPattern1());
    }
    /*private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(m_skillPos.position, 3);
    }*/
    void Pattern2()
    {
            Debug.Log("패턴 2 시작");
            
    }
    public List<GameObject> list = new List<GameObject>();
    void bossSkill1()
    {
        Collider2D[] col = Physics2D.OverlapCircleAll(m_skillPos.transform.position, 3f, m_playerMask);
        foreach (Collider2D enemy in col)
        {
            if (((1 << enemy.gameObject.layer) & m_playerMask) != 0)
            {
                if (list.Contains(enemy.gameObject)) return;
                list.Add(enemy.gameObject);
            }
        }
    }
    /*IEnumerator BossPattern1()
    {
        Collider2D[] col = Physics2D.OverlapCircleAll(m_skillPos.transform.position, 3f, m_playerMask);

        foreach (Collider2D enemy in col)
        {
            testplayer player = enemy.GetComponent<testplayer>();
            list.Add(enemy.gameObject[]);
            float dmg = player.damage;
            if (player != null) player.damage = player.damage * 0.50f;
            yield return new WaitForSeconds(3f);
            if (player != null) player.damage = dmg;
            list.Remove(enemy.gameObject);
        }


    }*/

}
