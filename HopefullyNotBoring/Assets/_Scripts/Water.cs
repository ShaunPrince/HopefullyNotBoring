using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public PhysicMaterial normal;
    public PhysicMaterial frozen;

    public Material water;
    public Material ice;
    private bool isFrozen;
    // Start is called before the first frame update
    void Start()
    {
        isFrozen = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<PlayerMovement>().jumpForce = 3;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<PlayerMovement>().jumpForce = 10;
        }
    }

    public void Freeze()
    {
        if(!isFrozen)
        {
            isFrozen = true;
            this.GetComponent<Collider>().isTrigger = false;
            this.GetComponent<MeshRenderer>().material = ice;
            this.GetComponent<Collider>().material = frozen;
        }

    }

    public void Unfreeze()
    {
        if(isFrozen)
        {
            isFrozen = false;
            this.GetComponent<Collider>().isTrigger = true;
            this.GetComponent<MeshRenderer>().material = water;
            this.GetComponent<Collider>().material = normal;
        }
    }
}
