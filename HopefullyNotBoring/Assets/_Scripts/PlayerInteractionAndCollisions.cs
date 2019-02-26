using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionAndCollisions : MonoBehaviour
{

    public float VelocityStartFallDamage;
    public static bool canTakeFallDamage;
    // Start is called before the first frame update
    void Start()
    {
        canTakeFallDamage = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {

            if (Mathf.Abs(collision.relativeVelocity.y) >= VelocityStartFallDamage)
            {
                Debug.Log("Fall impact at rel velocity " + collision.relativeVelocity.y + " >= dmg start velocity: " + VelocityStartFallDamage);
            }
        }

    }
}
