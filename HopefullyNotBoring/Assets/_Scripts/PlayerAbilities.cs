using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public enum Season { winter, spring, summer, fall };
    public Season mySeason;

    public Material[] currentColor;

    public int seasonAbilityUsesRemaining;
    private CanvasUIManager canvasUI;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<MeshRenderer>().material = currentColor[(int)mySeason];
        canvasUI = GameObject.Find("Canvas").GetComponent<CanvasUIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForSeasonChange();
        CheckForAndUseSeasonAbility();

    }

    private void CheckForSeasonChange()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeSeason(Season.winter);
            canvasUI.UpdateSeasonText("Winter");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeSeason(Season.spring);
            canvasUI.UpdateSeasonText("Spring");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeSeason(Season.summer);
            canvasUI.UpdateSeasonText("Summer");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChangeSeason(Season.fall);
            canvasUI.UpdateSeasonText("Fall");
        }
    }

    private void ChangeSeason(Season newSeason)
    {
        mySeason = newSeason;
        this.GetComponent<MeshRenderer>().material = currentColor[(int)mySeason];
    }

    private void CheckForAndUseSeasonAbility()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(seasonAbilityUsesRemaining > 0)
            {
                seasonAbilityUsesRemaining--;
                switch (mySeason)
                {
                    case Season.winter:
                        Debug.Log("Winter Ability Used");
                        break;
                    case Season.spring:
                        Debug.Log("Spring Ability Used");
                        break;
                    case Season.summer:
                        Debug.Log("Summer Ability Used");
                        break;
                    case Season.fall:
                        Debug.Log("Fall Ability Used");
                        break;
                }
            }
            else
            {
                Debug.Log("Out of ability uses");
            }

        }
    }
}
