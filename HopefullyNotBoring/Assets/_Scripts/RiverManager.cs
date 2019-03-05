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
        int childrenLength = this.transform.childCount;
        riverPieces = new Transform[childrenLength];
        for (int i = 0; i < childrenLength; ++i)
        {
            riverPieces[i] = this.transform.GetChild(i);
            Transform riverPiece = riverPieces[i];
            riverPiece.GetChild(0).gameObject.SetActive(riverFilled); // Sets water block child of the river piece to be active or inactive
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FillAll()
    {
        if (riverFilled == false)
        {
            int size = riverPieces.Length;
            for (int i = 0; i < size; ++i)
            {
                Transform riverPiece = riverPieces[i];
                River riverScript = riverPiece.GetComponent<River>();
                riverScript.fillWater();
            }
            riverFilled = true;
        }
    }
}
