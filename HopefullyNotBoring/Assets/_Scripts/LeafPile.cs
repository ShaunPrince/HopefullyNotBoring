using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafPile : MonoBehaviour
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
        if(other.gameObject.CompareTag("Player"))
        {
            PlayerInteractionAndCollisions.canTakeFallDamage = false;
            //Debug.Log(PlayerInteractionAndCollisions.canTakeFallDamage);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerInteractionAndCollisions.canTakeFallDamage = true;
            //Debug.Log(PlayerInteractionAndCollisions.canTakeFallDamage);
        }

    }
}
