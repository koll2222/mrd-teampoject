using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//싱글톤
public class Managers : MonoBehaviour
{
    static Managers s_instance;//전역static약자
    //필요한 스크립트에 Managers mg = Managers.Instance; or Instance.UI 이런식으로 모든 곳에서 참조 가능하게 설계
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
        if(s_instance == null)//만약 없다면
        {
            GameObject go = GameObject.Find("@Managers");//매니저를 찾아서 넣어주고
            if(go == null)//그래도 없으면
            {
                go = new GameObject { name = "@managers" };//새로 생성 후 컴포넌트 추가
                go.AddComponent<Managers>();
            }
            DontDestroyOnLoad(go);//삭제 못하게
            s_instance = go.GetComponent<Managers>();//go에 있는 값을 instance에 넣어줌
        }
    }
}
