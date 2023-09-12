using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.Events;
public class GameManager : Singleton<GameManager>
{
    //게임 흐름 관련
    [SerializeField] Text m_textGameClear;
    bool m_isLive = false;
    bool m_isPlaying = false;
    
    //타이머 관련
    [SerializeField] Text m_textTimer;
    [SerializeField] public float m_curTime = 0;
    int m_timerDefault = 30;
    
    //라운드 관련
    [SerializeField] Text m_textRound;
    int m_roundCount = 0;
    int m_endOfRound = 10;
    
    //골드 관련
    [SerializeField] Text m_textGold;
    int m_curGold = 0;

    //남은 적 확인
    [SerializeField] Text m_textEnemys;
    int m_curEnemys = 0;

    //죽인 적
    [SerializeField] Text m_textKillScore;
    int m_curKillScore = 0;

    //기타
    [SerializeField] UnityEvent m_roundCheck;
    
    private void Start()
    {
        m_isPlaying = true;
        m_isLive = true;
        m_curTime = 5f;
    }

    private void Update()
    {
        if(m_isLive && m_isPlaying)
        {
            Timer();
        }
    }
    void Timer()
    {
        m_curTime -= 1 * Time.deltaTime;
        if(m_curTime <= 0f)
        {
            m_curTime = m_timerDefault;
            m_roundCount++;
            m_roundCheck?.Invoke();
            if (m_roundCount > m_endOfRound)//라운드 종료시점
            {
                m_isPlaying = false;
                GameClear();
            }
        }
            //나중에 UI매니저로 뺄 것
            m_textTimer.text = "Time : " + Mathf.Floor(m_curTime);
            m_textRound.text = "Round : " + m_roundCount.ToString();
    }
    public void Gold(int money)
    {
        m_curGold += money;
        m_textGold.text = "Gold : " + m_curGold;
    }
    public void Enemys(int enemys)
    {
        m_curEnemys += enemys;
        if (m_curEnemys >= 10) Debug.Log("gameover");
        m_textEnemys.text = "Enemys : " + m_curEnemys;
    }
    public void KillScore(int kills)
    {
        m_curKillScore += kills;
        m_textKillScore.text = "Kills : " + m_curKillScore;
    }
    void GameClear()
    {
        m_textGameClear.gameObject.SetActive(true);
    }
}
