using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManage : MonoBehaviour
{
    public GameObject m_optionPanel;
    public void Optionpanel()
    {
        Time.timeScale = 0;
        m_optionPanel.SetActive(true);

    }
    public void Return()
    {
        Time.timeScale = 1;
        m_optionPanel.SetActive(false);
    }
    public void AnotherOption()
    {
        // sound 
        //graphics
    }
    public void GoMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuGame");
    }
    public void QuitGame()
    {
        Application.Quit();

    }

}
