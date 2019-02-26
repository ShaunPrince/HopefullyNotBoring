using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    private CanvasUIManager canvasUI;
    private int myHP;
    private bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        canvasUI = GameObject.Find("Canvas").GetComponent<CanvasUIManager>();
        myHP = 3;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
            GameOver();
    }

    public void TakeDamage(int dmg)
    {
        if (myHP - dmg > 0)
        {
            myHP -= dmg;
            canvasUI.UpdateHPText(myHP.ToString());
        }
        else
        {
            myHP = 0;
            isDead = true;
        }
    }

    private void GameOver()
    {
        Debug.Log("You are dead");
    }
}
