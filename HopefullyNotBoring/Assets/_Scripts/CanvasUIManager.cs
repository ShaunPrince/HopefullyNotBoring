using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasUIManager : MonoBehaviour
{
    private Text playerSeason;
    private Text playerHP;
    // Start is called before the first frame update
    void Start()
    {
        playerSeason = this.transform.GetChild(0).transform.GetComponent<Text>();
        playerSeason.text = "Season: Winter";
        playerHP = this.transform.GetChild(1).transform.GetComponent<Text>();
        playerHP.text = "Health: 3";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateSeasonText(string newSeason)
    {
        playerSeason.text = "Season: " + newSeason;
    }

    public void UpdateHPText(string newHP)
    {
        playerHP.text = "Health: " + newHP;
    }
}
