using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillHit : MonoBehaviour
{
    public Animator m_myAnim = null;

    private void Awake()
    {
        m_myAnim = GetComponent<Animator>();
    }

    public void SetPlay(string _skillName, float _attackSpeed = 1f)
    {
        //m_myAnim.SetFloat("attackSpeed", _attackSpeed = _attackSpeed < 1 ? 1 : _attackSpeed > 4 ? 3 : _attackSpeed);
        m_myAnim.Play(_skillName);
    }

    public void DonePlay()
    {
        ObjectPool.Instance.ReleaseHitEffect(this);
    }
}
