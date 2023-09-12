using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    //프리팹 보관
    [SerializeField] GameObject[] m_prefabs;
    //풀 담당
    List<GameObject>[] m_pools;
    
    private void Awake()
    {
        //프리팹 수만큼 List 배열 크기 초기화
        m_pools = new List<GameObject>[m_prefabs.Length];

        for(int index = 0; index < m_prefabs.Length; index++)
        {
            //각각의 배열 데이터 List 초기화
            m_pools[index] = new List<GameObject>();
        }
    }

    //가져다가 사용할 함수
    public GameObject Get(int index)
    {
        GameObject select = null;
        //비활성화 된 오브젝트 찾기
        foreach(GameObject data in m_pools[index])
        {
            //죽어 있다면 찾아서 생성
            if (!data.activeSelf)
            {
                select = data;
                select.SetActive(true);
                break;
            }
        }
        
        //새롭게 생성하는 오브젝트
        if (!select)
        {
            select = Instantiate(m_prefabs[index], transform) as GameObject;
            //생성된 ob, 풀 추가
            m_pools[index].Add(select);
        }

        return select;
    }
}
