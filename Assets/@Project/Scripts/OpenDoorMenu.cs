using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpenDoorMenu : MonoBehaviour
{
  public Text m_text;
    public string m_leverName;
    private bool m_indoor=false;

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("Player"))
            {
            m_text.gameObject.SetActive(true);
            m_indoor = true;

        }
      

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        m_text.gameObject.SetActive(false);
        m_indoor = false;
    }
    private void Update()
    {
        if(m_indoor && Input.GetKey("x")) {
            SceneManager.LoadScene(m_leverName);
        }
    }
}
