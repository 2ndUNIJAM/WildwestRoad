using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{


    private void Awake()
    {
        Screen.SetResolution(1920, 1080, false);
    }
    void Start()
    {
    }
    public void StartBtn()
    {
        SceneManager.LoadScene("GameScene"); //게임시작버튼을누르면  게임씬을 불러옴
    }
    public void ExitBtn()
    {
        Application.Quit(); //프로그램종료
    }
    public void HowToPlayBtn()
    {
        //게임설명과 관련된 페널창 띄우기
    }

    public void ExplainPanel()
    {

    }
}
