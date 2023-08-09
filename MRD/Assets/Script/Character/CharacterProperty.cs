using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterProperty : MonoBehaviour
{



    // Get Animator
    Animator _myAnim;
    protected Animator myAnim
    {
        get
        {
            if (_myAnim == null)
            {
                _myAnim = GetComponent<Animator>();
                if(_myAnim == null)
                {
                    _myAnim = GetComponentInChildren<Animator>();
                }
            }return _myAnim;
        }
    }

}
