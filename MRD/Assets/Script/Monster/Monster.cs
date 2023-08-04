using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class Monster : MonsterMoveMent
{   
    void Start()
    {
        transform.position = wayPoint[nextPoint].transform.position;
    }
    void Update()
    {
        moveing();
    }

}
