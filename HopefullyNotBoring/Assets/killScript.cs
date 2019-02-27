using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killScript : MonoBehaviour
{
    public GameObject SceneManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        SceneManager.GetComponent<SceneScript>().ResetScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
