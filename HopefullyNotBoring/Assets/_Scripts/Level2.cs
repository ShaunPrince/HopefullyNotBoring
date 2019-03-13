using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject tree1;
    public GameObject tree2;
    public GameObject tree3;

    private TreeManager winTree1;
    private TreeManager winTree2;
    private TreeManager winTree3;
    // Start is called before the first frame update
    void Start()
    {
        winTree1 = tree1.GetComponent<TreeManager>();
        winTree2 = tree1.GetComponent<TreeManager>();
        winTree3 = tree1.GetComponent<TreeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (winTree1.GetHasWater() && winTree2.GetHasWater() && winTree3.GetHasWater())
            YouWin();
    }

    private void YouWin()
    {
        winPanel.SetActive(true);
    }

    //public void LoadNextScene()
    //{
      //  UnityEngine.SceneManagement.SceneManager.LoadScene("Level2");
    //}
}
