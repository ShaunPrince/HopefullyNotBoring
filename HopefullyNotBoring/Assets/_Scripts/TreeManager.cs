using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : MonoBehaviour
{
    private bool hasWater;
    private Material branch1, branch2, branch3;

    public Color greenBranch;
    public Color dryBranch;
    // Start is called before the first frame update
    void Start()
    {
        hasWater = false;
        branch1 = this.transform.GetChild(0).GetChild(1).transform.GetComponent<Renderer>().material;
        branch2 = this.transform.GetChild(0).GetChild(2).transform.GetComponent<Renderer>().material;
        branch3 = this.transform.GetChild(0).GetChild(3).transform.GetComponent<Renderer>().material;
        UpdateColors();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void giveWater()
    {
        Grow();
        hasWater = true;

        UpdateColors();
    }

    public void depleteWater()
    {
        hasWater = false;
        UpdateColors();
    }

    private void UpdateColors()
    {
        Color newColor;
        if (hasWater)
            newColor = greenBranch;
        else
            newColor = dryBranch;
        branch1.color = newColor;
        branch2.color = newColor;
        branch3.color = newColor;
    }

    private void Grow()
    {
        for (int i = 0; i < 4; ++i)
        {
            this.transform.GetChild(0).GetChild(i).gameObject.SetActive(true);
        }
        this.transform.GetChild(0).GetChild(4).gameObject.SetActive(false);
        if(!hasWater)
        {
            this.GetComponentInChildren<Animation>().Play();
            //this.transform.Translate(0, .5f, 0);
        }



    }

    public void Burn()
    {
        for (int i = 0; i < 4; ++i)
        {
            this.transform.GetChild(0).GetChild(i).gameObject.SetActive(false);
        }
        this.transform.GetChild(0).GetChild(4).gameObject.SetActive(true);
        hasWater = false;
    }
}
