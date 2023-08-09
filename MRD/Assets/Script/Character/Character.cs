using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Character : CharacterProperty
{
    //TODO: 배틀 시스템 구현

    [SerializeField] float m_attackSpeed = 1;
    [SerializeField] float m_attackCoolTime = 0;
    [SerializeField] float m_currentAttackCoolTime = 0;
    [SerializeField] float m_attackRange = 5;

    public TMPro.TMP_InputField m_input = null;
    public TMPro.TextMeshProUGUI m_text = null;

    [SerializeField] float m_moveSpeed = 1;

    [SerializeField] List<Transform> m_enemyList = null;

    [SerializeField] STATE m_myState = STATE.Normal;

    public enum STATE
    {
        Normal, Battle
    }

    public void ChangeState()
    {
        if (m_enemyList.Count < 1) m_myState = STATE.Normal;
        else
        {
            if (m_myState == STATE.Battle) return;
            else m_myState = STATE.Battle;
        }

        switch (m_myState)
        {
            case STATE.Normal:
                Debug.Log("Normal");
                StopAllCoroutines();
                break;
            case STATE.Battle:
                Debug.Log("Battle");
                StopAllCoroutines();
                StartCoroutine(Attacking());
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnInputFieldChange(TMPro.TMP_InputField _input)
    {
        SetAttackSpeed(float.Parse(_input.text));
    }

    public void AddEnemy(Transform _enemy)
    {
        m_enemyList.Add(_enemy);
        ChangeState();
    }

    public void RemoveEnemy(Transform _enemy)
    {
        if (m_enemyList.Contains(_enemy))
        {
            m_enemyList.Remove(_enemy);
        }
        else
        {
            return;
        }
        ChangeState();
    }

    void SetAttackSpeed(float _attackSpeed)
    {
        m_attackSpeed = _attackSpeed;

        m_attackCoolTime = 1f / m_attackSpeed;

        m_currentAttackCoolTime = m_attackCoolTime;

        if (m_attackSpeed > 1) myAnim.SetFloat("attackSpeed", m_attackSpeed);
        else myAnim.SetFloat("attackSpeed", 1);

        m_text.text = string.Format("공격 속도 : {0}\n" +
                                      "공격 애니메이션 재생하는데 걸리는 시간 : {1}\n" +
                                      "공격 쿨타임 {2}/{3}", m_attackSpeed, 1f / m_attackSpeed, m_currentAttackCoolTime, m_attackCoolTime);
    }
    
    IEnumerator Attacking()
    {
        while (true)
        {
            if(m_currentAttackCoolTime >= m_attackCoolTime)
            {
                myAnim.SetTrigger("attack");
                m_currentAttackCoolTime = 0;
            }

            m_text.text = string.Format("공격 속도 : {0}\n" +
                                      "공격 애니메이션 재생하는데 걸리는 시간 : {1}\n" +
                                      "공격 쿨타임 {2}/{3}", m_attackSpeed, 1f / m_attackSpeed, m_currentAttackCoolTime, m_attackCoolTime);

            m_currentAttackCoolTime += Time.deltaTime;
            yield return null;
        }
    }

}
