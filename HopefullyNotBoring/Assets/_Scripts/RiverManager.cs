using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverManager : MonoBehaviour
{
    private Transform[] riverPieces;
    public bool riverFilled;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FillAll()
    {
        if (riverFilled == false)
        {
            for(int i = 0; i < this.transform.childCount; ++i)
            {
                this.transform.GetChild(i).gameObject.SetActive(true);
            }
            foreach (River r in this.transform.GetComponentsInChildren<River>())
            {
                r.fillWater();
            }
            riverFilled = true;


        }
    }
}
