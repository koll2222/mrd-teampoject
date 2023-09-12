using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    //������ ����
    [SerializeField] GameObject[] m_prefabs;
    //Ǯ ���
    List<GameObject>[] m_pools;
    
    private void Awake()
    {
        //������ ����ŭ List �迭 ũ�� �ʱ�ȭ
        m_pools = new List<GameObject>[m_prefabs.Length];

        for(int index = 0; index < m_prefabs.Length; index++)
        {
            //������ �迭 ������ List �ʱ�ȭ
            m_pools[index] = new List<GameObject>();
        }
    }

    //�����ٰ� ����� �Լ�
    public GameObject Get(int index)
    {
        GameObject select = null;
        //��Ȱ��ȭ �� ������Ʈ ã��
        foreach(GameObject data in m_pools[index])
        {
            //�׾� �ִٸ� ã�Ƽ� ����
            if (!data.activeSelf)
            {
                select = data;
                select.SetActive(true);
                break;
            }
        }
        
        //���Ӱ� �����ϴ� ������Ʈ
        if (!select)
        {
            select = Instantiate(m_prefabs[index], transform) as GameObject;
            //������ ob, Ǯ �߰�
            m_pools[index].Add(select);
        }

        return select;
    }
}
