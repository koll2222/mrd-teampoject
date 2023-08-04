using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour
{
    public Text text_Timer;
    public Text text_Round;
    public Text text_gameClear;
    public float curTime;
    float maxTime;
    int totalRound;
    int startRound;
    int endOfRound;
    //나중에 고칠 것 isLive
    bool isLive = false;
    bool isPlaying = false;
   
    private void Awake()
    {
        maxTime = 30;
        endOfRound = 30;
        curTime = maxTime;
        totalRound = startRound;
        isPlaying = true;
        isLive = true;
    }
    void Start()
    {
        
        
    }

   
    void Update()
    {
        if(isLive && isPlaying)
        {
            Timer();
        }
    }

    void Timer()
    {
        if (curTime >= 0)
        {
            curTime -= 1 * Time.deltaTime;
        }
        else//0초가 되면
        {
            totalRound++;
            curTime = maxTime;
            if (totalRound >= endOfRound)
            {
                GameClear();
                Timer();
            }
        }
        text_Timer.text = "Time : " + Mathf.Floor(curTime);
        text_Round.text = "Round : " + totalRound.ToString();
    }

    void GameClear()
    {
        text_gameClear.gameObject.SetActive(true);
        isPlaying = false;
    }

}
