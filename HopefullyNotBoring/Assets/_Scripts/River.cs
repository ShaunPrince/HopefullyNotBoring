using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class River : MonoBehaviour
{
    private GameObject waterBlock;
    // Start is called before the first frame update
    void Start()
    {
        waterBlock = this.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void fillWater()
    {
        waterBlock.SetActive(true);
        waterBlock.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1.0f, this.transform.position.z);
        //waterBlock.transform.localScale = this.transform.localScale;
        waterBlock.transform.rotation = this.transform.rotation;
    }
}
