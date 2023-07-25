using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Sound
{
    public string name;//��
    public AudioClip clip;//��
}
public class SoundManager : MonoBehaviour
{
    //�ڽ��� instance ����� static�� ���� ��𼭵� ȣ�� ����
    static public SoundManager instance;
    #region singleton
    private void Awake()//��ü ���� �� ���� ����
    {
        if (instance == null)//���ٸ� �ڱ� �ڽ� ����
        {
            instance = this;
            DontDestroyOnLoad(instance);//���⿡ gameobj�־�� �� �� ���� �̵��� Ȯ��
        }
        else//�����Ѵٸ� �ڱ� �ڽŻ���
            Destroy(this.gameObject);
        
    }
    #endregion singleton
    //mp3
    public AudioSource[] audioSourcesEffects;//���� ����� ���� �迭
    public AudioSource audioSourceBgm;
    //���
    public Sound[] effectSounds;
    public Sound[] bgmSounds;
    
    public void PlaySE(string _name)//_name�� �Ѿ���� Sound���� name�� �ִٸ� clip�� �ְ� ����
    {
        for (int i = 0; i < effectSounds.Length; i++)
        {
            if(_name == effectSounds[i].name)//�Ѿ�� �Ͱ� ��ġ�ϸ� ����
            {
                for(int j = 0; j < audioSourcesEffects.Length; j++)
                {
                    if (!audioSourcesEffects[j].isPlaying)//is
                    {
                        //audioSourcesEffects[j].clip ==;
                    }
                }
            }
        }
    }
}
