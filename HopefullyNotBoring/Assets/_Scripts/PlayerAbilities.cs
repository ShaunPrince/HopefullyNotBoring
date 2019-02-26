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
    public float leafUpwardThrust;

    public int seasonAbilityUsesRemaining;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponentInChildren<MeshRenderer>().material = currentColor[(int)mySeason];
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
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeSeason(Season.spring);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeSeason(Season.summer);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ChangeSeason(Season.fall);
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
                switch (mySeason)
                {
                    case Season.winter:
                        Debug.Log("Winter Ability Used");
                        WinterAbility();
                        break;
                    case Season.spring:
                        Debug.Log("Spring Ability Used");
                        break;
                    case Season.summer:
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
}
