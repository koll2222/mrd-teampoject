using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testplayer : MonsterProperty
{
    float attackTime = 0f;
    float attackSpeed = 1f;
    public float damage = 20f;
    public LayerMask enemyMask;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        attackTime += Time.deltaTime * attackSpeed;
        if (attackTime >= 1.0f) 
        {
            OnAttack();
            attackTime = 0.0f;
        }
    }
    void OnAttack()
    {
        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(transform.position, 2.3f, enemyMask);
        foreach (Collider2D enemy in hitEnemy)
        {
            if (enemy.GetComponent<Monster>().isLive != false) enemy.GetComponent<BattleSystem>().TakeDamage(damage);
        }
    }
}
