using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainCloud : MonoBehaviour
{
    public GameObject rainPrefab;
    public float duration;
    public float timeSinceSpawn;
    // Start is called before the first frame update
    void Start()
    {
        timeSinceSpawn = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceSpawn += Time.deltaTime;
        if(timeSinceSpawn <= duration)
        {
            float xOffset = Random.Range(-2.5f, 2.5f);
            Instantiate(rainPrefab, this.transform.position + new Vector3(xOffset, -.3f, 0), Quaternion.identity);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
