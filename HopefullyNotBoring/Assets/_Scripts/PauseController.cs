using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    public bool isPaused;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            isPaused = false;
            if (panel == null)
            {
                panel = GameObject.Find("Panel");
            }
            GameObject instructions = panel.transform.GetChild(2).gameObject;
            DeavtivateTutorial(instructions);
            panel.SetActive(false);
        }
        else
        {
            Time.timeScale = 0f;
            isPaused = true;
            panel.SetActive(true);
        }
    }

    public void QuitGame()
    {
        UnityEngine.Application.Quit();
    }

    private void DeavtivateTutorial(GameObject tutorial)
    {
        int panels = tutorial.transform.childCount;
        for (int i = 1; i < panels; ++i)
        {
            GameObject screen = tutorial.transform.GetChild(i).gameObject;
            screen.SetActive(false);
        }
    }
}
