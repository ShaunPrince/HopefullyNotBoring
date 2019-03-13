using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheck : MonoBehaviour
{
    Rigidbody _rb;

    // Start is called before the first frame update
    void Start()
    {
        _rb = this.GetComponentInParent<Rigidbody>();
        //Debug.Log(_rb.gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            if (_rb.velocity.y > 0)
            {
                _rb.velocity = new Vector3(_rb.velocity.x, 0, 0);
            }
        }
        else if(other.gameObject.CompareTag("Water") && other.gameObject.GetComponent<Water>().isFrozen == true)
        {
            if (_rb.velocity.y > 0)
            {
                _rb.velocity = new Vector3(_rb.velocity.x, 0, 0);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
