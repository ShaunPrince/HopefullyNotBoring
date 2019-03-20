using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    public GameObject winPanel;
    public string nextLvl;
    //public GameObject sceneManager;

    //private SceneScript sceneScript;
    private GameObject[] allTrees;
    private TreeManager[] winTrees;
    private float time;
    // Start is called before the first frame update
    void Start()
    {
        allTrees = GameObject.FindGameObjectsWithTag("Tree");
        int size = allTrees.Length;
        winTrees = new TreeManager[allTrees.Length];
        for (int i = 0; i < size; ++i)
        {
            winTrees[i] = allTrees[i].transform.GetComponent<TreeManager>();
        }
        time = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (AllWatered())
        {
            if (winPanel.activeSelf == false)
                winPanel.SetActive(true);
            if (time < 3.0f)
                time += Time.deltaTime;
            else
                LoadNextScene();
        }
    }

    private bool AllWatered()
    {
        foreach (TreeManager tree in winTrees)
        {
            if (!tree.GetHasWater())
                return false;
        }
        return true;
    }

    private void YouWin()
    {
        winPanel.SetActive(true);
    }

    public void LoadNextScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nextLvl);
    }
}
