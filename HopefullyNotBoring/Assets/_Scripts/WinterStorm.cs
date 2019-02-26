using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinterStorm : MonoBehaviour
{
    public float stormDuration = 2f;
    public float timeSinceSpawn;
    // Start is called before the first frame update
    void Start()
    {
        timeSinceSpawn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceSpawn += Time.deltaTime;
        if (timeSinceSpawn >= stormDuration)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            other.GetComponent<Water>().Freeze();
        }
    }

}

