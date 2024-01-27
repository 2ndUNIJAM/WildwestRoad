using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuController : MonoBehaviour
{

    public GameObject SelectPanel;
    private void Awake()
    {
        Screen.SetResolution(1920, 1080, false);
    }
    void Start()
    {
        SoundManager.Instance.PlayBGM(SoundType.MenuBGM);
        SelectPanel.SetActive(false);
    }
    public void StartBtn()
    {
        SelectPanel.SetActive(true);
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
