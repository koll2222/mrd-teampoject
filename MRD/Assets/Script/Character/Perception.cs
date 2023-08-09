using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perception : MonoBehaviour
{
    [SerializeField] Character myParent = null;

    private void Start()
    {
        myParent = GetComponentInParent<Character>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        myParent.AddEnemy(collision.transform);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        myParent.RemoveEnemy(collision.transform);
    }
}
