using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Sound
{
    public string name;//명
    public AudioClip clip;//곡
}
public class SoundManager : MonoBehaviour
{
    //자신의 instance 만들고 static을 통해 어디서든 호출 가능
    static public SoundManager instance;
    #region singleton
    private void Awake()//객체 생성 시 최초 실행
    {
        if (instance == null)//없다면 자기 자신 넣음
        {
            instance = this;
            DontDestroyOnLoad(instance);//여기에 gameobj넣어야 될 지 ㅇㅇ 이따가 확인
        }
        else//존재한다면 자기 자신삭제
            Destroy(this.gameObject);
        
    }
    #endregion singleton
    //mp3
    public AudioSource[] audioSourcesEffects;//동시 재생을 위해 배열
    public AudioSource audioSourceBgm;
    //곡들
    public Sound[] effectSounds;
    public Sound[] bgmSounds;
    
    public void PlaySE(string _name)//_name이 넘어오면 Sound내부 name이 있다면 clip에 넣고 실행
    {
        for (int i = 0; i < effectSounds.Length; i++)
        {
            if(_name == effectSounds[i].name)//넘어온 것과 일치하면 실행
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
