using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FruitsGroup : MonoBehaviour
{
    public Text m_levelClearn;
    public Text m_totalFruits;
    public Text m_fruisCollected;
    private int totalFruitInlever;
   void Start()
    {
        totalFruitInlever = transform.childCount;

    }
    private void Update()
    {
        AllFruitsCollected();
        m_totalFruits.text = totalFruitInlever.ToString();
        m_fruisCollected.text = transform.childCount.ToString();

    }
    public void AllFruitsCollected()
    {
        if (transform.childCount == 0)
        {
            // Debug.Log("no Fruits");
            //úing prefab is bug
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    }
}
