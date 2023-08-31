using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{

    // 가중치 랜덤 확률 라이브러리
    Rito.WeightedRandomPicker<CharacterData> m_wrPicker = new Rito.WeightedRandomPicker<CharacterData>();
    CharacterData m_rndPick;

    // 캐릭터의 데이터를 담아둘 변수
    [SerializeField]
    private List<CharacterData> m_characterDatas;

    // 캐릭터의 기본 틀 프리팹
    [SerializeField]
    private GameObject m_characterPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SetRandomList();
    }
    public bool check = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RandomSpawn();
        }
    }

    // 캐릭터 데이터를 랜덤 뽑기 리스트에 추가
    public void SetRandomList()
    {
        //for (int i = 0; i < m_characterDatas.Count; i++)
        //{
        //    if ((int)m_characterDatas[i].grade > 3) m_wrPicker.Add(m_characterDatas[i], 1);
        //    else if ((int)m_characterDatas[i].grade > 2) m_wrPicker.Add(m_characterDatas[i], 5);
        //    else if ((int)m_characterDatas[i].grade > 1) m_wrPicker.Add(m_characterDatas[i], 14);
        //    else m_wrPicker.Add(m_characterDatas[i], 80);
        //}
        foreach(CharacterData _data in m_characterDatas)
        {
            if ((int)_data.grade > 3) m_wrPicker.Add(_data, 1);
            else if ((int)_data.grade > 2) m_wrPicker.Add(_data, 5);
            else if ((int)_data.grade > 1) m_wrPicker.Add(_data, 14);
            else m_wrPicker.Add(_data, 80);
        }
    }

    public void RandomSpawn()
    {
        Character newCharacter = Instantiate(m_characterPrefab).GetComponent<Character>();
        newCharacter.m_characterdata = m_rndPick = m_wrPicker.GetRandomPick();
        newCharacter.name = m_rndPick.name;
        newCharacter.SetStatus();

        print(m_rndPick);
    }
}
