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

        if (canTakeFallDamage && Mathf.Abs(collision.relativeVelocity.y) >= VelocityStartFallDamage)
        {
            this.GetComponent<PlayerLife>().TakeDamage(1);
            Debug.Log("Fall impact at rel velocity " + collision.relativeVelocity.y + " >= dmg start velocity: " + VelocityStartFallDamage);
        }


    }
}
