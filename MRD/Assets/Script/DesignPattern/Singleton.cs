using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _inst;
    public static T Instance
    {
        get
        {
            if(_inst == null)
            {
                _inst = (T)FindObjectOfType(typeof(T));  // 이 함수의 T 타입은 오브젝트
                if(_inst == null)
                {
                    GameObject obj = new GameObject(typeof(T).Name, typeof(T));
                    _inst = obj.GetComponent<T>();
                }
            }
            return _inst;
        }
    }
    private void Awake()
    {
        if(transform.parent != null && transform.root != null)
        {
            DontDestroyOnLoad(this.transform.root.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
