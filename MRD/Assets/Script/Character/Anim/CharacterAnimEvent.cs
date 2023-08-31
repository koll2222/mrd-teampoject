using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterAnimEvent : MonoBehaviour
{
    [SerializeField] UnityEvent SkillEffect;
    [SerializeField] UnityEvent HitEffect;
    [SerializeField] UnityEvent Projectile;

    public void PlaySkillEffect()
    {
        SkillEffect?.Invoke();
    }

    public void PlayHitEffect()
    {
        HitEffect?.Invoke();
    }

    public void ProjectileAttack()
    {
        Projectile?.Invoke();
    }
}
