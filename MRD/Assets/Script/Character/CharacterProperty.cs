using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterProperty : MonoBehaviour
{

    public CharacterData m_characterdata;
    public SkillData m_skillData;

    [SerializeField] protected float m_damage;
    [SerializeField] protected float m_attackSpeed;
    [SerializeField] protected float m_attackRange;
    [SerializeField] protected float m_attackCoolTime;
    [SerializeField] protected float m_currentAttackCoolTime;

    [SerializeField] protected string m_myClass;
    [SerializeField] protected string m_myGrade;

    public void SetStatus()
    {
        m_damage = m_characterdata.damage;
        m_attackSpeed = m_characterdata.attackSpeed;
        m_attackRange = m_characterdata.attackRange;
        m_attackCoolTime = m_characterdata.attackCoolTime;
        m_currentAttackCoolTime = m_characterdata.currentAttackCoolTime;
        m_myClass = m_characterdata.characterClass.ToString();
        m_myGrade = m_characterdata.grade.ToString();
    }

    // Get Animator
    Animator _myAnim;
    protected Animator myAnim
    {
        get
        {
            if (_myAnim == null)
            {
                _myAnim = GetComponent<Animator>();
                if(_myAnim == null)
                {
                    _myAnim = GetComponentInChildren<Animator>();
                }
            }return _myAnim;
        }
    }

}
