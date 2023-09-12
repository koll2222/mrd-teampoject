using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Monster : MonsterMoveMent, IBattle
{
    public float testattack = 35f;
    private void FixedUpdate()
    {
        if (!isLive) return;
        Moveing();
    }
    void Update()
    {
        TestAttack();
        /*if (CurHp <= m_maxHp * 0.75 && !test)
        {
            Debug.Log(CurHp);
        }*/
        if (m_colliderControl)
        {
            m_colliderControl = false;
            ResizeCollider();
        }
        
    }
    public bool isLive
    {
        get
        {
            if (!Mathf.Approximately(CurHp, 0))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    private void OnEnable()
    {
        MonsterReSetting();
    }

    void TestAttack()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !Mathf.Approximately(m_curHp, 0))
        {
            TakeDamage(testattack);
        }
    }

    public void Init(SpawnData data)
    {
        //라운드 별 컨트롤러 변경
        myAnim.runtimeAnimatorController = m_animCon[data.spriteType];
        m_moveSpeed = data.speed;
        m_maxHp = data.hp;
        CurHp = data.hp;
    }

    public void BossInit(SpawnData data)
    {
        m_moveSpeed = data.speed;
        m_maxHp = data.hp;
        CurHp = data.hp;
    }

    void MonsterReSetting()
    {
        m_nextPoint = 1;
        m_colliderControl = true;
    }

    private void ResizeCollider()
    {
        if(myRenderer != null && myCollider2D != null)
        {
            float colliderRadius = myRenderer.bounds.size.x / 2f;
            myCollider2D.radius = colliderRadius;
        }
    }
}
