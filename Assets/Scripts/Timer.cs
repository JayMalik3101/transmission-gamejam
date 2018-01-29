using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour {
    [SerializeField] private Text TimerText;
    [SerializeField] private float m_gametimer;
    [SerializeField] private float m_swirltimer = 120;
    [SerializeField] private GameObject Victory;
    [SerializeField] private GameObject Player1Showcase;
    [SerializeField] private GameObject Player2Showcase;
    [SerializeField] private GameObject Player3Showcase;
    [SerializeField] private GameObject Player4Showcase;
    [SerializeField] private GameObject Player1Active;
    [SerializeField] private GameObject Player2Active;
    [SerializeField] private GameObject Player3Active;
    [SerializeField] private GameObject Player4Active;
    [SerializeField] private GameObject PurgatoryTheme;


    

    void Update () {
        
        m_gametimer -= Time.deltaTime;
        TimerText.text = Mathf.Round(m_gametimer).ToString();
        if(m_gametimer <= 0)
        {
            PurgatoryTheme.SetActive(false);
            Player1Active.SetActive(false);
            Player2Active.SetActive(false);
            Player3Active.SetActive(false);
            Player4Active.SetActive(false);
            TimerText.gameObject.SetActive(false);
            Victory.SetActive(true);
            if(Player1Active.tag == "TestPlayer")
            {
                Player1Showcase.SetActive(true);
            }
            if (Player2Active.tag == "TestPlayer")
            {
                Player2Showcase.SetActive(true);
            }
            if (Player3Active.tag == "TestPlayer")
            {
                Player3Showcase.SetActive(true);
            }
            if (Player4Active.tag == "TestPlayer")
            {
                Player4Showcase.SetActive(true);
            }

            
        }
	}
}
