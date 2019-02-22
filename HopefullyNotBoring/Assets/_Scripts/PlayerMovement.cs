using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    public float moveSpeed = 1;
    public float jumpForce;
    public float VelocityStartFallDamage;
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
            if(deltaX > 0 && _rb.velocity.x > 0 || deltaX < 0 && _rb.velocity.x < 0)
            {
                _rb.velocity = _rb.velocity;
            }
            else if (deltaX != 0)
            {
                _rb.velocity = new Vector3(deltaX * moveSpeed / 2, _rb.velocity.y, 0);
            }
        }
    }

    private void Jump()
    {
        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Floor"))
        {

            if (Mathf.Abs(collision.relativeVelocity.y) >= VelocityStartFallDamage)
            {
                Debug.Log("Fall impact at rel velocity " + collision.relativeVelocity.y + " >= dmg start velocity: " + VelocityStartFallDamage);
            }
        }
    }

    private void CheckGrounded()
    {

        //still need to check for what is below it (is it a floor?)
        //current layermask ignores the Player layer (layer 10)
        if(Physics.Raycast(this.transform.position, Vector3.down, out RaycastHit hit, 1f, ~(1 << 10)))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        
    }

}
