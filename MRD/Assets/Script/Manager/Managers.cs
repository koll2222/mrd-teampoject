using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�̱���
public class Managers : MonoBehaviour
{
    static Managers s_instance;
    public static Managers Instance { get { init(); return s_instance; } }//������ �Ŵ��� �����
    //�����Դµ� null���� ���� ������, init�� �־��� �Ʒ����� �����Ͽ� ������ �ڵ�
    private void Start()
    {
        init();
    }
    private void Update()
    {
        
    }
    static void init()
    {
        if(s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if(go == null)
            {
                go = new GameObject { name = "@managers" };//���� ���� �� ������Ʈ �߰�
                go.AddComponent<Managers>();
            }
            DontDestroyOnLoad(go);//���� ���ϰ�
            s_instance = go.GetComponent<Managers>();//go�� �ִ� ���� instance�� �־���
        }
    }
}
