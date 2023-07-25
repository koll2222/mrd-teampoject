using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{

    [SerializeField] GameObject m_BackgroundImg;
    RectTransform m_BackRect;

    //[SerializeField] GameObject m_FirstScreen;

    [SerializeField] GameObject m_SecondScreen;
    RectTransform m_SecondRect;

    [SerializeField] public float m_Speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        m_BackRect = m_BackgroundImg.GetComponent<RectTransform>();
        m_SecondRect = m_SecondScreen.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeScreen()
    {
        //float backgroundPositionY = m_BackgroundImg.GetComponent<RectTransform>().anchoredPosition.y;
        float secondPositionY = m_SecondRect.anchoredPosition.y;
        Vector3 secondScreenPosition = new Vector3(m_BackRect.anchoredPosition.x, -(secondPositionY - 40), 0);
        //while (Mathf.Approximately(m_BackRect.anchoredPosition.y, secondScreenPosition.y) == false)
        //{
        //    //m_BackRect.anchoredPosition = Vector3.Lerp(m_BackRect.anchoredPosition, secondScreenPosition, Time.deltaTime);
        //    m_BackRect.anchoredPosition = new Vector2(secondScreenPosition.x, Mathf.Lerp(m_BackRect.anchoredPosition.y, secondScreenPosition.y, Time.deltaTime));

        //}
        StopAllCoroutines();
        StartCoroutine(ScreenLerping());
    }

    IEnumerator ScreenLerping()
    {
        float targetPositionY = -(m_SecondRect.anchoredPosition.y - 40);
        Vector3 targetScreenPosition = new Vector3(m_BackRect.anchoredPosition.x, targetPositionY, 0);
        while (!Mathf.Approximately(m_BackRect.anchoredPosition.y, targetPositionY))
        {
            m_BackRect.anchoredPosition = Vector2.Lerp(m_BackRect.anchoredPosition, targetScreenPosition, m_Speed);
            yield return null;
            if ((m_BackRect.anchoredPosition.y - targetPositionY) < 3) m_BackRect.anchoredPosition = targetScreenPosition;
            Debug.Log(Mathf.Approximately(m_BackRect.anchoredPosition.y, targetPositionY));
            Debug.Log(m_BackRect.anchoredPosition.y);
            Debug.Log(targetPositionY);
        }
        StopAllCoroutines();
        Debug.Log("끝 실행 끝");
    }

}
