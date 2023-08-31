using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDamage
{
    //TODO: 배틀 시스템 코드 작성
    public interface IDamageable
    {
        void TakeDamage(float _dmg);
    }
}
