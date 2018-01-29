using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhoIsTheDemon : MonoBehaviour {
    [SerializeField] private Transform m_PlayerOneTransform;
    [SerializeField] private Transform m_PlayerTwoTransform;
    [SerializeField] private Transform m_PlayerThreeTransform;
    [SerializeField] private Transform m_PlayerFourTransform;
    // Use this for initialization
    void Start () {
        int WhoIsTheDemon = Random.Range(1, 4);
        if (WhoIsTheDemon == 1)
        {
            m_PlayerOneTransform.tag = "Possesed";
        }
        else if (WhoIsTheDemon == 2)
        {
            m_PlayerTwoTransform.tag = "Possesed";
        }
        else if (WhoIsTheDemon == 3)
        {
            m_PlayerThreeTransform.tag = "Possesed";
        }
        else if (WhoIsTheDemon == 4)
        {
            m_PlayerFourTransform.tag = "Possesed";
        }
    }
}
