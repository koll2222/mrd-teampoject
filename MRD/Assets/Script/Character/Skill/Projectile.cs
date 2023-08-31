using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Vector2 m_dir = Vector2.zero;
    [SerializeField]float m_dist = 0;
    public float m_speed = 10f;
    float m_delta = 0;

    public void StartThrowing(Transform _target, string _skillName)
    {
        StartCoroutine(Throwing(_target, _skillName));
    }

    IEnumerator Throwing(Transform _target, string _skillName)
    {
        m_dir = _target.position - transform.position;
        m_dist = m_dir.magnitude;
        m_dir.Normalize();
        while (m_dist > 0)
        {
            m_delta = m_speed * Time.deltaTime;
            if (m_dist - m_delta < 0.0f)
            {
                m_delta = m_dist;
            }
            transform.Translate(m_dir * m_delta);
            m_dist -= m_delta;
            if(Mathf.Approximately(m_dist, 0.0f))
            {
                ObjectPool.Instance.GetHitEffect(_skillName, 1f, _target);
                StopAllCoroutines();
                ObjectPool.Instance.ReleaseProjectile(this);
            }
            yield return null;
        }
    }
}
