using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rb;
    public float moveSpeed = 1;
    public float airMoveSpeed;
    public float jumpForce;
    public float defaultJumpForce;
    public float inWaterJumpForce;

    public bool isJumping;

    public bool isGrounded;
    public float maxHorSpeed;

    private float curMoveSpeed;

    private Vector3 normalVect;

    private float deltaX;

    private RaycastHit useRayHit = new RaycastHit();

    public LayerMask layersToRayHit;



    // Start is called before the first frame update
    void Start()
    {
        _rb = this.GetComponent<Rigidbody>();
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(this.transform.position, Quaternion.AngleAxis(-90, Vector3.forward) * normalVect * 100, Color.yellow);
        if (_rb.IsSleeping())
        {
            _rb.WakeUp();
        }
        CheckGrounded();
        deltaX = Input.GetAxisRaw("Horizontal");
        Jump();
    }

    private void FixedUpdate()
    {
        Move();


    }

    private void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
    }


    private void Move()
    {


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
                //_rb.velocity = _rb.velocity +  Quaternion.AngleAxis(-90, Vector3.forward) * normalVect * curMoveSpeed * deltaX;
                _rb.AddForce(Quaternion.AngleAxis(-90,Vector3.forward)*normalVect*curMoveSpeed*deltaX, ForceMode.VelocityChange);
                // Quaternion.AngleAxis(-90, Vector3.forward) * normalVect * 10, Color.yellow);

            }
            else
            {
                _rb.velocity = new Vector3(maxHorSpeed, _rb.velocity.y, 0);
            }
        }
        else if (deltaX < 0)
        {
            if (_rb.velocity.x + deltaX * curMoveSpeed >= -maxHorSpeed)
            {
                //_rb.velocity = _rb.velocity + Quaternion.AngleAxis(-90, Vector3.forward) * normalVect * curMoveSpeed * deltaX;
                _rb.AddForce(Quaternion.AngleAxis(-90, Vector3.forward) * normalVect * curMoveSpeed * deltaX, ForceMode.VelocityChange);
                //Debug.Log(Quaternion.AngleAxis(-90, Vector3.forward) * normalVect);
                
            }
            else
            {
                _rb.velocity = new Vector3(-maxHorSpeed, _rb.velocity.y, 0);
            }
        }
        else if (isGrounded)
        {
            if(useRayHit.collider.gameObject.CompareTag("Water"))
            {
                if(useRayHit.collider.gameObject.GetComponent<Water>().isFrozen == true)
                {
                    if (_rb.velocity.y < this.gameObject.GetComponent<PlayerInteractionAndCollisions>().VelocityStartFallDamage)
                    {
                        _rb.velocity = Vector3.zero;
                    }
                    else
                    {
                        _rb.velocity = new Vector3(0, _rb.velocity.y, 0);
                    }
                }
                else
                {


                }
            }
            else
            {
                if (_rb.velocity.y < this.gameObject.GetComponent<PlayerInteractionAndCollisions>().VelocityStartFallDamage)
                {
                    _rb.velocity = Vector3.zero;
                }
                else
                {
                    _rb.velocity = new Vector3(0, _rb.velocity.y, 0);
                }


            }
        }


    }



    private void Jump()
    {
        if(isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            isGrounded = false;
            isJumping = true;
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }



    private void CheckGrounded()
    {

        //still need to check for what is below it (is it a floor?)
        //current layermask ignores the Player layer (layer 10)
        Debug.DrawRay(this.transform.position, Vector3.down * 1.01f, Color.red);
        Debug.DrawRay(this.transform.position + Vector3.right * .5f, Vector3.down * 1.01f, Color.red);
        Debug.DrawRay(this.transform.position + Vector3.left * .5f, Vector3.down * 1.01f, Color.red);
        bool mid = Physics.Raycast(this.transform.position, Vector3.down, out RaycastHit hitM, 1.01f, layersToRayHit);
        bool right = Physics.Raycast(this.transform.position + Vector3.right * .5f, Vector3.down, out RaycastHit hitR, 1.01f,layersToRayHit);
        bool left = Physics.Raycast(this.transform.position + Vector3.left * .5f, Vector3.down, out RaycastHit hitL, 1.01f, layersToRayHit);
        bool beenSet = false;
        useRayHit = new RaycastHit();

        if (mid)
        {
            useRayHit = hitM;
            beenSet = true;
        }

        if(left)
        {
            if(beenSet)
            {
                if(hitL.distance < useRayHit.distance)
                {
                    useRayHit = hitL;
                }
            }
            else
            {
                useRayHit = hitL;
                beenSet = true;
            }

        }

        if(right)
        {
            if(beenSet)
            {
                if(hitR.distance < useRayHit.distance)
                {
                    useRayHit = hitR;
                }
            }
            else
            {
                useRayHit = hitR;
                beenSet = true;
            }
        }


        if(beenSet && !isJumping)
        {
            //Debug.Log(hit.transform.gameObject);
            //_rb.useGravity = false;
            //Debug.Log(useRayHit.normal);
            normalVect = useRayHit.normal;
            isGrounded = true;
            //Debug.Log(useRayHit.collider.gameObject);
        }
        else
        {
            //_rb.useGravity = true;
            normalVect = Vector3.up;
            isGrounded = false;
        }
        //Debug.Log(isGrounded);
        
    }

}
