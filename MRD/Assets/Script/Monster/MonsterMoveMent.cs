using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMoveMent : MonsterProperty
{
    [SerializeField] protected float moveSpeed = 1f;
    [SerializeField] protected int nextPoint = 0;
    [SerializeField] protected Transform[] wayPoint;
    protected void moveing()
    {
        myAnim.SetBool("isMoving", true);
        float delta = moveSpeed * Time.deltaTime;
        if (nextPoint >= 3)
        {
            myRenderer.flipX = false;
        }
        else
        {
            myRenderer.flipX = true;
        }
        transform.position = Vector2.MoveTowards(transform.position, wayPoint[nextPoint].transform.position, delta);
        if (transform.position == wayPoint[nextPoint].transform.position)
        {
            nextPoint++;
        }
        if (nextPoint == wayPoint.Length)
        {
            nextPoint = 0;
        }
    }
}
