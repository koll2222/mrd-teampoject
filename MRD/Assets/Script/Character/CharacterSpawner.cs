using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{

    // ����ġ ���� Ȯ�� ���̺귯��
    Rito.WeightedRandomPicker<CharacterData> m_wrPicker = new Rito.WeightedRandomPicker<CharacterData>();
    CharacterData m_rndPick;

    // ĳ������ �����͸� ��Ƶ� ����
    [SerializeField]
    private List<CharacterData> m_characterDatas;

    // ĳ������ �⺻ Ʋ ������
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

    // ĳ���� �����͸� ���� �̱� ����Ʈ�� �߰�
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
