using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {

        if(other.gameObject.transform.parent != null && other.gameObject.transform.parent.gameObject.CompareTag("Tree"))
        {
            Debug.Log("HitTree");
            other.gameObject.transform.parent.gameObject.GetComponent<TreeManager>().giveWater();
            Destroy(this.gameObject);
        }
        if(other.gameObject.CompareTag("Floor"))
        {
            Destroy(this.gameObject);
        }
    }
}

