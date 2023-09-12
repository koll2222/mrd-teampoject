using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMoveMent : BattleSystem
{
    public float testspeed = 1;
    private void Awake()
    {
        m_movePoint = SpawnerManager.m_wayPoints;
    }
    protected void Moveing()
    {
        myAnim.SetBool("isMoving", true);
        myRenderer.flipX = m_nextPoint >= 3 ? false : true;

        float delta = m_moveSpeed * Time.deltaTime* testspeed;
        transform.position = Vector2.MoveTowards(transform.position, m_movePoint[m_nextPoint].transform.position, delta);

        if (transform.position == m_movePoint[m_nextPoint].transform.position)
        {
            m_nextPoint++;
        }

        if (m_nextPoint == m_movePoint.Length)
        {
            m_nextPoint = 0;
        }
    }
}
