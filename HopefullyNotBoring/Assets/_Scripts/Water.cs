using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public PhysicMaterial normal;
    public PhysicMaterial frozen;

    public HashSet<GameObject> otherWaters;

    public Material water;
    public Material ice;

    public bool isFrozen;

    // Start is called before the first frame update
    private void Awake()
    {
        if (isFrozen)
        {
            isFrozen = false;
            Freeze();
            foreach (Water waterBlock in this.transform.parent.parent.GetComponentsInChildren<Water>())
            {
                waterBlock.Freeze();
            }
        }
    }

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<PlayerMovement>().jumpForce = FindObjectOfType<PlayerMovement>().inWaterJumpForce;
        }

        if(other.gameObject.CompareTag("River") && this.isFrozen == false)
        {
            other.GetComponentInParent<RiverManager>().FillAll();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<PlayerMovement>().jumpForce = FindObjectOfType<PlayerMovement>().defaultJumpForce;
        }
    }

    public void Freeze()
    {
        if(!this.isFrozen)
        {

            isFrozen = true;
            this.GetComponent<Collider>().isTrigger = false;
            this.GetComponent<MeshRenderer>().material = ice;


        }

    }

    public void Unfreeze()
    {
        if(this.isFrozen)
        {

            this.isFrozen = false;
            this.GetComponent<Collider>().isTrigger = true;
            this.GetComponent<MeshRenderer>().material = water;

        }
    }

}
