using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//싱글톤
public class Managers : MonoBehaviour
{
    static Managers s_instance;
    public static Managers Instance { get { init(); return s_instance; } }//유일한 매니저 갖고옴
    //가져왔는데 null값일 수도 있으니, init을 넣어줌 아래서도 선언하여 안전한 코딩
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
                go = new GameObject { name = "@managers" };//새로 생성 후 컴포넌트 추가
                go.AddComponent<Managers>();
            }
            DontDestroyOnLoad(go);//삭제 못하게
            s_instance = go.GetComponent<Managers>();//go에 있는 값을 instance에 넣어줌
        }
    }
}
