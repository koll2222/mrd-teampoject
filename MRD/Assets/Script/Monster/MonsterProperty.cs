using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MonsterProperty : MonoBehaviour
{
    //제어
    Animator _anim = null;
    SpriteRenderer _renderer = null;
    CircleCollider2D _collider = null;
    //이동
    protected float m_moveSpeed = 0f;
    protected int m_nextPoint = 0;
    protected Transform[] m_movePoint;

    //체력
    protected float m_maxHp;
    protected float m_minHp = 0f;
    public float m_curHp;

    public float CurHp
    {
        get { return m_curHp; }
        set { m_curHp = Mathf.Clamp(value, m_minHp, m_maxHp); }
    }
    //사망
    public UnityAction m_deathAlarm;

    //기타
    [SerializeField] protected RuntimeAnimatorController[] m_animCon;
    protected bool m_colliderControl = true;

    protected SpriteRenderer myRenderer
    {
        get
        {
            if (_renderer == null)
            {
                _renderer = GetComponent<SpriteRenderer>();
                if (_renderer == null)
                {
                    _renderer = GetComponentInChildren<SpriteRenderer>();
                }
            }
            return _renderer;
        }
    }
    protected Animator myAnim
    {
        get
        {
            if (_anim == null)
            {
                _anim = GetComponent<Animator>();
                if (_anim == null)
                {
                    _anim = GetComponentInChildren<Animator>();
                }
            }
            return _anim;
        }
    }
    protected CircleCollider2D myCollider2D
    {
        get
        {
            if (_collider == null)
            {
                _collider = GetComponent<CircleCollider2D>();
                if (_renderer == null)
                {
                    _collider = GetComponentInChildren<CircleCollider2D>();
                }
            }
            return _collider;
        }
    }
}
