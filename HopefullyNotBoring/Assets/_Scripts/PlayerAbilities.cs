using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public enum Season { winter, spring, summer, fall };
    public Season mySeason;

    public Material[] currentColor;

    public GameObject leafPile;
    public GameObject winterStorm;
    public GameObject rainCloud;
    public GameObject sunBeam;
    public float leafUpwardThrust;

    public int seasonAbilityUsesRemaining;
    private CanvasUIManager canvasUI;
    // Start is called before the first frame update
    void Start()
    {


        this.GetComponentInChildren<MeshRenderer>().material = currentColor[(int)mySeason];
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
        this.GetComponentInChildren<MeshRenderer>().material = currentColor[(int)mySeason];
    }

    private void CheckForAndUseSeasonAbility()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(seasonAbilityUsesRemaining > 0)
            {
                seasonAbilityUsesRemaining--;
                canvasUI.UpdateUsesRemaining(seasonAbilityUsesRemaining.ToString());
                switch (mySeason)
                {
                    case Season.winter:
                        Debug.Log("Winter Ability Used");
                        WinterAbility();
                        break;
                    case Season.spring:
                        Debug.Log("Spring Ability Used");
                        SpringAbility();
                        break;
                    case Season.summer:
                        SummerAbility();
                        Debug.Log("Summer Ability Used");
                        break;
                    case Season.fall:
                        Debug.Log("Fall Ability Used");
                        FallAbility();
                        break;
                }
            }
            else
            {
                Debug.Log("Out of ability uses");
            }

        }
    }


    private void FallAbility()
    {
        this.GetComponent<Rigidbody>().AddForce(Vector3.up * leafUpwardThrust , ForceMode.Impulse);
        Instantiate(leafPile, this.transform.position + Vector3.down,Quaternion.identity);

    }

    private void WinterAbility()
    {
        Instantiate(winterStorm, this.transform);
    }

    private void SpringAbility()
    {
        Instantiate(rainCloud, this.transform.position + Vector3.up*3 , Quaternion.AngleAxis(90f,Vector3.forward),this.transform);
    }

    private void SummerAbility()
    {
        Instantiate(sunBeam, this.transform.position + Vector3.right + Vector3.down, Quaternion.identity);
        Instantiate(sunBeam, this.transform.position + Vector3.left + Vector3.down, Quaternion.AngleAxis(180f,Vector3.forward));

    }
}
