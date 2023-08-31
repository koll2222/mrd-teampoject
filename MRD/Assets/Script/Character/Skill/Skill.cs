using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public Animator m_myAnim = null;
    public List<Animator> m_childAnim;

    private void Awake()
    {
        m_myAnim = GetComponent<Animator>();
        //int a = GetComponentsInChildren<Animator>().Length;
    }

    public void SetPlay(string _class, string _grade, float _attackSpeed = 1f)
    {
        m_myAnim.SetFloat("attackSpeed", _attackSpeed = _attackSpeed < 1 ? 1 : _attackSpeed > 4 ? 3 : _attackSpeed);
        m_myAnim.Play(_class + _grade);
    }

    public void DonePlay()
    {
        ObjectPool.Instance.ReleaseSkillEffect(this);
    }

    public void SetChildPlay(float _attackSpeed = 1f)
    {
        foreach(Animator anim in m_childAnim)
        {
            anim.SetFloat("attackSpeed", _attackSpeed);
            anim.SetTrigger("attack");
        }
    }
    
}
