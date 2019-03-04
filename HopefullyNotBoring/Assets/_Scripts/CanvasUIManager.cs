using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasUIManager : MonoBehaviour
{
    private Text playerSeason;
    private Text usesRemaining;
    // Start is called before the first frame update
    void Start()
    {
        playerSeason = this.transform.GetChild(0).transform.GetComponent<Text>();
        //playerSeason.text = "Season: Winter";
        usesRemaining = this.transform.GetChild(1).transform.GetComponent<Text>();
        //usesRemaining.text = "Uses: 4";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateSeasonText(string newSeason)
    {
        playerSeason.text = "Season: " + newSeason;
    }

    public void UpdateSeasonColor(Color newColor)
    {
        playerSeason.color = newColor;
        UpdateUsesColor(newColor);
    }

    //public void UpdateHPText(string newHP)
    //{
    //    playerHP.text = "Health: " + newHP;
    //}

    public void UpdateUsesRemaining(string newUses)
    {
        usesRemaining.text = "Uses: " + newUses;
    }

    private void UpdateUsesColor(Color newColor)
    {
        usesRemaining.color = newColor;
    }
}
