using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerManager : Singleton<SpawnerManager>
{
    //������� ����
    [SerializeField] Transform[] m_wayPoint;
    public static Transform[] m_wayPoints;
    //��������
    int m_stage = 0;
    //���� �� �ð� ����
    [SerializeField] SpawnData[] m_spawnData;
    float m_spawnTime = 1f;
    float m_respawnCoolTime = 0f;
    //���Ƿ� ���� �׽�Ʈ �ð�
    float m_timeA = 15;
    public float m_timeB = 30;
    bool istestbool = true;
    private void Awake()
    {
        m_wayPoints = m_wayPoint;//�����Ʈ ��������
    }
    private void Update()
    {
        //ReSpawnTime();
        if(Input.GetKeyDown(KeyCode.A))BossSpawn();
    }
    
    void ReSpawnTime()
    {
        if(m_stage <= 9)
        {
            if (m_stage >= 1 && GameManager.Instance.m_curTime >= 15)//1ROUND���� ũ�� 15�� �̻��� �� ����
            {
                m_spawnTime += Time.deltaTime;
                if (m_spawnTime >= m_respawnCoolTime)
                {
                    Spawn();
                    m_spawnTime = 0f;
                }
            }
        }
        else if(m_stage > 9 && m_stage < 11)
        {
            if (istestbool)
            {
                BossSpawn();
                istestbool = false;
            }
        }
    }
    public void RoundUpdate()
    {
        m_stage++;
        m_respawnCoolTime = m_timeA / m_timeB;
    }
    void Spawn()
    {
        GameObject enemy = PoolManager.Instance.Get(0);
        enemy.transform.position = m_wayPoint[0].transform.position;
        enemy.GetComponent<Monster>().Init(m_spawnData[m_stage-1]);//�Ŵ����� üũ�ϱ� ������ -1, �׸��� ������ ������
        GameManager.Instance.Enemys(1);
    }
    void BossSpawn()
    {
        GameObject boss = PoolManager.Instance.Get(1);
        boss.transform.position = m_wayPoint[0].transform.position;
        boss.GetComponent<Monster>().BossInit(m_spawnData[10 - 1]);
        GameManager.Instance.Enemys(1);
    }
}

[System.Serializable]
public class SpawnData
{
    public float spawnTime;
    public int spriteType;
    public int hp;
    public float speed;
}