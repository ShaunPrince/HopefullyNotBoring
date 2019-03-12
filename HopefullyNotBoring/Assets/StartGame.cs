using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GameObject m_buttonText;
    // Start is called before the first frame update
    void Awake()
    {
    }

    public void GoToLevel1()
    {
        SceneManager.LoadScene("Level1Dup");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
