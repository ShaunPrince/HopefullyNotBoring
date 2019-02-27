using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    public float moveSpeed = 1;
    public float airMoveSpeed;
    public float jumpForce;

    private bool isGrounded;
    public float maxHorSpeed;

    private float curMoveSpeed;

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

        if(isGrounded)
        {
            curMoveSpeed = moveSpeed;
        }
        else
        {
            curMoveSpeed = airMoveSpeed;
        }

        if (deltaX > 0)
        {
            if (_rb.velocity.x + deltaX * curMoveSpeed <= maxHorSpeed)
            {
                _rb.AddForce(deltaX * curMoveSpeed, 0, 0, ForceMode.VelocityChange);
            }
            else
            {
                //_rb.velocity = new Vector3(maxHorSpeed, _rb.velocity.y, 0);
            }
        }
        else if (deltaX < 0)
        {
            if (_rb.velocity.x + deltaX * curMoveSpeed >= -maxHorSpeed)
            {
                _rb.AddForce(deltaX * curMoveSpeed, 0, 0, ForceMode.VelocityChange);
            }
            else
            {
                //_rb.velocity = new Vector3(-maxHorSpeed, _rb.velocity.y, 0);
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



    private void CheckGrounded()
    {

        //still need to check for what is below it (is it a floor?)
        //current layermask ignores the Player layer (layer 10)
        //Debug.DrawRay(this.transform.position, Vector3.down * 3f, Color.red);
        if(Physics.Raycast(this.transform.position, Vector3.down, out RaycastHit hit, 3f, ~(1 << 10)))
        {            
            //Debug.Log(hit.transform.gameObject);
            isGrounded = true;
        }
        else
        {

            isGrounded = false;
        }
        //Debug.Log(isGrounded);
        
    }

}
