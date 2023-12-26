using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Move : MonoBehaviour
{
    public float speedX;
    public float speedY;
    private Transform transform;
    private Rigidbody2D rb;
    public float normalSpeed;
    private float moveInput1;
    private float moveInput2;
    public Button moveButtonUp;
    public Button moveButtonDown;
    public Button moveButtonR;
    public Button moveButtonL;
    public Animator animator;
    void Start()
    {
        speedX = 0f;
        speedY = 0f;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        moveInput1 = Input.GetAxis("Horizontal");
        moveInput2 = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(speedX, speedY);
    }
    public void OnLButton() 
    {
        if (speedX>=0f) 
        {
            speedX= -normalSpeed;
        }
        animator.SetFloat("MoveParL", Mathf.Abs(1));
    }
    public void OnRButton() 
    {
        if (speedX <= 0f)
        {
            speedX = normalSpeed;
        }
        animator.SetFloat("MoveParR", Mathf.Abs(1));
    }
    public void OnUpButton() 
    {
        if (speedY <= 0f)
        {
            speedY = normalSpeed;
        }
        animator.SetFloat("MoveParDown", Mathf.Abs(1));
    }
    public void OnDownButton() 
    {
        if (speedY >= 0f)
        {
            speedY = -normalSpeed;
        }
        animator.SetFloat("MovePar", Mathf.Abs(1));
    }
    public void OnNotButtonUp() 
    {
        speedX = 0f;
        speedY = 0f;
        animator.SetFloat("MoveParDown", Mathf.Abs(0));
    }
    public void OnNotButtonDown()
    {
        speedX = 0f;
        speedY = 0f;
        animator.SetFloat("MovePar", Mathf.Abs(0));
    }
    public void OnNotButtonR()
    {
        speedX = 0f;
        speedY = 0f;
        animator.SetFloat("MoveParR", Mathf.Abs(0));
    }
    public void OnNotButtonL()
    {
        speedX = 0f;
        speedY = 0f;
        animator.SetFloat("MoveParL", Mathf.Abs(0));
    }
}
