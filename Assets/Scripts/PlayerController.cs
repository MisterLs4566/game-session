using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Controls controls;
    private Vector2 horizontalInput;
    private Rigidbody2D rb;
    private Animator anim;
    public float speed, jumpHeight, groundDistance;
    public LayerMask groundLayer;
    public int jumps;
    private int jumpsPossible;

    void Awake()
    {
        controls = new Controls();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        jumpsPossible = 0;
    }

    private void OnEnable()
    {
        controls.Enable();
        controls.Main.Jump.performed += Jump;
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    void Start()
    {
        
    }

    void Update()
    {
        horizontalInput = controls.Main.Movement.ReadValue<Vector2>();

        if(horizontalInput.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(horizontalInput.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180f, 0);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput.x * speed, rb.velocity.y);
    }

    void Jump(InputAction.CallbackContext ctx)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundDistance, groundLayer);
        
        if (hit.collider != null )
        {
            jumpsPossible = jumps-1;
            rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);   
        }
        else if(jumpsPossible > 0)
        {
            jumpsPossible -= 1;
            rb.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
        }

        //Debug.DrawRay(transform.position, Vector2.down * groundDistance, Color.red);
    }
}
