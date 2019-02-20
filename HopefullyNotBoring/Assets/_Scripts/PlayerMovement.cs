using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    public float moveSpeed = 1;
    public float jumpForce;
    public float negVelocityStartFallDamage;
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        _rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGrounded();
        Debug.Log(isGrounded);
        Move();
        Jump();
    }



    private void Move()
    {
        float deltaX = Input.GetAxisRaw("Horizontal");
        if (isGrounded)
        {
            _rb.velocity = new Vector3(deltaX * moveSpeed, _rb.velocity.y, 0);
        }
        else
        {
            //half movespeed control while airborne (not functional)
            //_rb.velocity = new Vector3((deltaX * moveSpeed / 2), _rb.velocity.y, 0);
        }
    }

    private void Jump()
    {
        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }
    }

    private void CheckGrounded()
    {

        //still need to check for what is below it (is it a floor?)
        //current layermask ignores the Player layer (layer 10)
        if(Physics.Raycast(this.transform.position, Vector3.down, out RaycastHit hit, 1f, ~(1 << 10)))
        {
            //Debug.Log(hit.collider.transform.gameObject);
            if(_rb.velocity.y <= negVelocityStartFallDamage)
            {
                Debug.Log("Fall impact at velocity " + _rb.velocity.y + " <= dmg start neg velocity: " + negVelocityStartFallDamage);
            }
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        
    }

}
