using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilLaughCue : MonoBehaviour {
    [SerializeField] private GameObject EvilLaugh;
    private float m_Timer = 3;
    private void FixedUpdate()
    {
        if (gameObject.tag == "Possesed")
        {
            EvilLaugh.SetActive(true);
            m_Timer -= Time.deltaTime;
            if (m_Timer <= 0)
            {
                EvilLaugh.SetActive(false);
            }
        }
        if (gameObject.tag == "TestPlayer")
        {
            m_Timer = 3;
        }
    }
}
