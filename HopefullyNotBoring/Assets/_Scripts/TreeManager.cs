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
        branch1 = this.transform.GetChild(1).transform.GetComponent<Renderer>().material;
        branch2 = this.transform.GetChild(2).transform.GetComponent<Renderer>().material;
        branch3 = this.transform.GetChild(3).transform.GetComponent<Renderer>().material;
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
        if(!hasWater)
        {
            this.transform.Translate(0, .5f, 0);
            this.transform.localScale = new Vector3(2, 2, 1);
        }

    }
}
