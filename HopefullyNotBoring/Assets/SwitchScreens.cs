using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScreens : MonoBehaviour
{

    public GameObject m_nextScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SwitchTheScreen()
    {
        m_nextScreen.SetActive(true);
        gameObject.transform.parent.gameObject.SetActive(false);
    }
}
