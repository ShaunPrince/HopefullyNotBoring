using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class River : MonoBehaviour
{
    public GameObject waterPrefab;
    public bool isEmpty;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fill()
    {
        if (isEmpty)
        {
            Vector3 thisPos = this.transform.position;
            Vector3 thisScale = this.transform.localScale;
            GameObject water = GameObject.Instantiate(waterPrefab, new Vector3(thisPos.x, thisPos.y + 1.0f, thisPos.z), this.transform.rotation);
            water.transform.localScale = thisScale;
            isEmpty = false;
        }
    }
}
