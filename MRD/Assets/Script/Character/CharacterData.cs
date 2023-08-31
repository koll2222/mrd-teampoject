using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character Data", menuName = "Scriptable Object/Character Data", order = 0)]

public class CharacterData : ScriptableObject
{
    [SerializeField]
    public enum CHARACTERCLASS
    {
        Warrior = 1, Wizard, Thief
    }
    public CHARACTERCLASS characterClass;
    
    [SerializeField]
    public enum GRADE
    {
        First = 1, Second, Third, Fourth
    }
    public GRADE grade;
    
    
    [SerializeField]
    private float _damage;
    public float damage { get { return _damage;} }
    
    [SerializeField] 
    private float _attackSpeed;
    public float attackSpeed { get { return _attackSpeed; } }
   
    [SerializeField] 
    private float _attackRange;
    public float attackRange { get { return _attackRange; } }
    
    // 공격 쿨타임은 개별로 가지고 있어야 할 거 같음 -> 이 방식으로 구현해보고 수정
    [SerializeField] 
    private float _attackCoolTime;
    public float attackCoolTime { get { return _attackCoolTime; } }
   
    [SerializeField] 
    private float _currentAttackCoolTime;
    public float currentAttackCoolTime { get { return _currentAttackCoolTime; } }
}
