using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Mon : MonoBehaviour, IDamage.IDamageable
{

    [SerializeField]private float hp = 10000f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float _dmg)
    {
        hp -= _dmg;
        Debug.Log($"{hp} - {_dmg}");
    }
}
