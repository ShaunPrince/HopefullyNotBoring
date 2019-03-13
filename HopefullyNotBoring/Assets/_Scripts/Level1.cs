using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    public GameObject winPanel;
    //public GameObject sceneManager;

    //private SceneScript sceneScript;
    private TreeManager winTree;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        winTree = GameObject.Find("Tree").GetComponent<TreeManager>();
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (winTree.GetHasWater())
        {
            if (time < 1.5f)
                time += Time.deltaTime;
            else
                LoadNextScene();
        }
    }

    private void YouWin()
    {
        winPanel.SetActive(true);
    }

    public void LoadNextScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level2");
    }
}
