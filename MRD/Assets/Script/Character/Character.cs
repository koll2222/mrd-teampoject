using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Character : CharacterProperty
{
    //TODO: 배틀 시스템 구현

    /* 개발 단계에서만 사용하는 코드 */
    public TMPro.TMP_InputField m_input = null;
    public TMPro.TextMeshProUGUI m_text = null;
    public void OnInputFieldChange(TMPro.TMP_InputField _input)
    {
        SetAttackSpeed(float.Parse(_input.text));
    }
    public Transform m_myTarget = null;
    /* 개발 단계에서만 사용하는 코드 */

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
                myAnim.ResetTrigger("attack");
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

    void Start()
    {
        SetStatus(); // 스폰 시킬 경우에는 지워야 함
        SetAttackSpeed(m_attackSpeed);
    }

    void Update()
    {

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
            if (m_myTarget == _enemy) m_myTarget = null;
            m_enemyList.Remove(_enemy);
        }
        else
        {
            return;
        }
        ChangeState();
    }

    public void SetAttackTarget()
    {
        if (m_enemyList.Count > 0 && m_myTarget == null)
        {
            m_myTarget = m_enemyList[Random.Range(0, m_enemyList.Count)];
        }
    }

    void SetAttackSpeed(float _attackSpeed)
    {
        m_attackSpeed = _attackSpeed;
        m_attackCoolTime = 1f / m_attackSpeed;
        m_currentAttackCoolTime = m_attackCoolTime;

        if (m_attackSpeed > 1) myAnim.SetFloat("attackSpeed", m_attackSpeed);
        else myAnim.SetFloat("attackSpeed", 1);
    }

    public void PlayEffect()    // 스킬 이펙트 재생
    {
        ObjectPool.Instance.GetSkillEffect(m_myClass, m_myGrade, m_attackSpeed, this.transform);
    }

    public void PlayHitEffect() // 스킬 피격 이펙트 재생
    {
        ObjectPool.Instance.GetHitEffect(m_skillData.m_name, 1, m_myTarget);
    }

    /* 나중에 바꿔야 함 */
    [SerializeField]float timer = 1;
    Coroutine coProjectile = null;

    IEnumerator Projectile()
    {
        Vector2 pos = this.transform.position;
        int i = 0;
        while (i < m_skillData.m_strokes)
        {
            if (timer > 0.2f)
            {
                ObjectPool.Instance.GetProjectile(m_skillData.m_name, pos, 1, m_myTarget);
                timer = 0;
                i++;
            }
            else timer += Time.deltaTime;
            yield return null;
        }
        StopCoroutine(coProjectile);
    }

    public void ThrowProjectile()
    {
        coProjectile = StartCoroutine(Projectile());
    }
    /* 나중에 바꿔야 함 */

    IEnumerator Attacking() // 공격
    {
        while (true)
        {
            if (myAnim.GetBool("isAttacking")) yield return new WaitUntil(() => !myAnim.GetBool("isAttacking"));
            if (m_currentAttackCoolTime >= m_attackCoolTime)
            {
                SetAttackTarget();
                myAnim.SetTrigger("attack");
                m_currentAttackCoolTime = 0;
            }
            else
            {
                m_currentAttackCoolTime += Time.deltaTime;
            }
            yield return null;
        }
    }

}
