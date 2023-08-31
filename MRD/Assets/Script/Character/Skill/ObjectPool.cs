using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : Singleton<ObjectPool>
{
    public GameObject m_skillEffectPrefab;
    Queue<Skill> m_skillEffectPool = new Queue<Skill>();

    public GameObject m_hitEffectPrefab;
    Queue<SkillHit> m_hitEffectPool = new Queue<SkillHit>();

    public GameObject m_projectilePrefab;
    Queue<Projectile> m_projectilePool = new Queue<Projectile>();

    private void Awake()
    {
        
    }

    /* 스킬 이펙트 */
    private Skill CreateNewSkillEffect()
    {
        Skill newObj = Instantiate(m_skillEffectPrefab, transform).GetComponent<Skill>();
        newObj.gameObject.SetActive(false);
        return newObj;
    }

    public Skill GetSkillEffect(string _class, string _grade, float _attackSpeed, Transform _parent = null)
    {
        if(m_skillEffectPool.Count > 0)
        {
            Skill obj = m_skillEffectPool.Dequeue();
            obj.transform.SetParent(_parent);
            obj.transform.localPosition = Vector2.zero;
            obj.gameObject.SetActive(true);
            obj.SetPlay(_class, _grade, _attackSpeed);
            return obj;
        }
        else
        {
            Skill obj = CreateNewSkillEffect();
            obj.transform.SetParent(_parent);
            obj.transform.localPosition = Vector2.zero;
            obj.gameObject.SetActive(true);
            obj.SetPlay(_class, _grade, _attackSpeed);
            return obj;
        }
    }

    public void ReleaseSkillEffect(Skill obj)
    {
        obj.transform.SetParent(transform);
        obj.gameObject.SetActive(false);
        m_skillEffectPool.Enqueue(obj);
    }

    /* 스킬 피격 이펙트 */
    private SkillHit CreateNewHitEffect()
    {
        SkillHit newObj = Instantiate(m_hitEffectPrefab, transform).GetComponent<SkillHit>();
        newObj.gameObject.SetActive(false);
        return newObj;
    }

    public SkillHit GetHitEffect(string _skillName, float _attackSpeed = 1f, Transform _parent = null)
    {
        if (m_hitEffectPool.Count > 0)
        {
            SkillHit obj = m_hitEffectPool.Dequeue();
            obj.transform.SetParent(_parent);
            obj.transform.localPosition = Vector2.zero;
            obj.gameObject.SetActive(true);
            obj.SetPlay(_skillName, _attackSpeed);
            return obj;
        }
        else
        {
            SkillHit obj = CreateNewHitEffect();
            obj.transform.SetParent(_parent);
            obj.transform.localPosition = Vector2.zero;
            obj.gameObject.SetActive(true);
            obj.SetPlay(_skillName, _attackSpeed);
            return obj;
        }
    }

    public void ReleaseHitEffect(SkillHit obj)
    {
        obj.transform.SetParent(transform);
        obj.gameObject.SetActive(false);
        m_hitEffectPool.Enqueue(obj);
    }

    private Projectile CreateNewProjectile()
    {
        Projectile newObj = Instantiate(m_projectilePrefab, transform).GetComponent<Projectile>();
        newObj.gameObject.SetActive(false);
        return newObj;
    }

    public Projectile GetProjectile(string _skillName, Vector2 _position, float _attackSpeed = 1f, Transform _target = null)
    {
        if (m_projectilePool.Count > 0)
        {
            Projectile obj = m_projectilePool.Dequeue();
            obj.transform.position = _position;
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            obj.StartThrowing(_target, _skillName);
            return obj;
        }
        else
        {
            Projectile obj = CreateNewProjectile();
            obj.transform.position = _position;
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            obj.StartThrowing(_target, _skillName);
            return obj;
        }
    }

    public void ReleaseProjectile(Projectile obj)
    {
        obj.transform.SetParent(transform);
        obj.gameObject.SetActive(false);
        m_projectilePool.Enqueue(obj);
    }
}
