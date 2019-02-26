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

    }

    public void Freeze()
    {
        if(!isFrozen)
        {
            isFrozen = true;
            this.GetComponent<MeshRenderer>().material = ice;
            this.GetComponent<Collider>().material = frozen;
        }

    }

    public void Unfreeze()
    {

    }
}
