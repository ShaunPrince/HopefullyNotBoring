using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunBeam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody>().velocity = this.transform.right * 18;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        //Destroy(this.gameObject);
        if (other.gameObject.CompareTag("Water"))
        {
            foreach (Water waterBlock in other.transform.parent.parent.GetComponentsInChildren<Water>())
            {
                waterBlock.Unfreeze();
            }
        }

        if(other.gameObject.transform.parent != null && other.gameObject.transform.parent.CompareTag("Tree"))
        {
            other.gameObject.transform.parent.gameObject.GetComponent<TreeManager>().Burn();
        }
    }
}
