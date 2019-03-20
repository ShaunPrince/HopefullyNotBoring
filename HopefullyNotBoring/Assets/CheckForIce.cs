using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForIce : MonoBehaviour
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
        //Debug.Log(other.gameObject);
        if (other.gameObject.GetComponent<Water>() != null)
        {
            if (other.gameObject.GetComponent<Water>().isFrozen == true)
            {
                //Debug.Log(this.gameObject);
                this.transform.parent.Translate(this.GetComponentInParent<PlayerMovement>().normalVect * .1f);
            }
        }
    }

}
