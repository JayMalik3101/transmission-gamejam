using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Onclicks : MonoBehaviour {
    [SerializeField] private string m_NextScene;

    public void OnClick(string name)
    {
        SceneManager.LoadScene(name);
    }
}
