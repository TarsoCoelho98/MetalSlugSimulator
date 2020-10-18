using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    public const byte WalkSpeed = 3;
    public const byte RunSpeed = 10;

    public byte Default = 0;
    public Rigidbody2D Rigid;
    public bool CanJump = false;

    public Collider2D Level;
    public float JumpForce = 6.5f;

    public Animator AnimHandler;
    public bool isAlive = true;

    public Transform Check;
    public LayerMask ItsLevel;
    public float Radius = 0.2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive)
        {
            SetDieAnim(true);
            return;
        }

        CanJump = Physics2D.OverlapCircle(Check.position, Radius, ItsLevel); // objeto verifica colisão dentro do raio com o objeto dentro da layer definida
                                                                             // check é um empty game object vinculado ao personagem que Checa colisão dentro do raio

        Flip();
        Move();
    }

    public void Fire()
    {
        if (Input.GetKey(KeyCode.F) && !Input.GetKey(KeyCode.A))
        {
            SetIdleFireAnim();
        }
        else if (Input.GetKey(KeyCode.F) && !Input.GetKey(KeyCode.D))
        {
            SetIdleFireAnim();
        }
        //else if (Input.GetKey(KeyCode.F) && Input.GetKey(KeyCode.D))
        //{
        //    SetWalkFireAnimOn();
        //} 
        //else if (Input.GetKey(KeyCode.F) && Input.GetKey(KeyCode.A))
        //{
        //    SetWalkFireAnimOn();
        //}
        else
        {
            SetIdleFireAnimOff();
            SetWalkFireAnimOff();
        }
    }

    public void Flip()
    {
        if (Input.GetKeyDown(KeyCode.A) && transform.localScale.x > 0)
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        else if (Input.GetKeyDown(KeyCode.D) && transform.localScale.x < 0)
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }

    public void SetIdleFireAnim()
    {
        AnimHandler.SetBool("isShooting", true);
        AnimHandler.SetBool("isIdle", false);
    }

    public void SetIdleFireAnimOff()
    {
        AnimHandler.SetBool("isShooting", false);
    }

    public void SetWalkFireAnimOn()
    {
        AnimHandler.SetBool("isWalkShooting", true);
        AnimHandler.SetBool("isWalking", false);
    }
    public void SetWalkFireAnimOff()
    {
        AnimHandler.SetBool("isWalkShooting", false);
        // AnimHandler.SetBool("isWalking", true);
    }

    public void SideJump()
    {
        if (Input.GetKeyDown(KeyCode.J) && CanJump && (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.R)))
        {
            SetSideJumpRunningAnim();
            Rigid.AddForce(new Vector2(Default, JumpForce), ForceMode2D.Impulse);
            UIManager.Instance.IncreaseJump();
        }
        else if (Input.GetKeyDown(KeyCode.J) && CanJump && (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.R)))
        {
            SetSideJumpRunningAnim();
            Rigid.AddForce(new Vector2(Default, JumpForce), ForceMode2D.Impulse);
            UIManager.Instance.IncreaseJump();
        }
        else if (Input.GetKeyDown(KeyCode.J) && CanJump && Input.GetKey(KeyCode.D))
        {
            SetSideJumpWalkingAnim();
            Rigid.AddForce(new Vector2(Default, JumpForce), ForceMode2D.Impulse);
            UIManager.Instance.IncreaseJump();
        }
        else if (Input.GetKeyDown(KeyCode.J) && CanJump && Input.GetKey(KeyCode.A))
        {
            SetSideJumpWalkingAnim();
            Rigid.AddForce(new Vector2(Default, JumpForce), ForceMode2D.Impulse);
            UIManager.Instance.IncreaseJump();
        }
        else if (Input.GetKeyDown(KeyCode.J) && CanJump)
        {
            SetSideJumpIdleAnim();
            Rigid.AddForce(new Vector2(Default, JumpForce), ForceMode2D.Impulse);
            UIManager.Instance.IncreaseJump();
        }
        else if (!Input.GetKeyDown(KeyCode.J) || !CanJump)
        {
            SetIdleAnimBeforeJump();
        }
    }

    public void Move()
    {
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.R))  // Running 
        {
            SetRunAnim();
            transform.Translate(Vector2.left * RunSpeed * Time.deltaTime);
            UIManager.Instance.TranslateBackground(false, RunSpeed);
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.R))
        {
            SetRunAnim();
            transform.Translate(Vector2.right * RunSpeed * Time.deltaTime);
            UIManager.Instance.TranslateBackground(true, RunSpeed);
        }
        else if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.F))  // Walking 
        {
            SetWalkAnim();
            transform.Translate(Vector2.left * WalkSpeed * Time.deltaTime);
            UIManager.Instance.TranslateBackground(false, WalkSpeed);
        }
        else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.F))
        {
            SetWalkAnim();
            transform.Translate(Vector2.right * WalkSpeed * Time.deltaTime);
            UIManager.Instance.TranslateBackground(true, WalkSpeed);
        }
        else if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            SetIdleAnim();

        Fire();
        SideJump();
    }

    public void SetIdleAnim()
    {
        AnimHandler.SetBool("isIdle", true);
        AnimHandler.SetBool("isWalking", false);
        AnimHandler.SetBool("isRunning", false);
    }

    public void SetIdleAnimBeforeJump()
    {
        AnimHandler.SetBool("isSideJumping", false);
        // AnimHandler.SetBool("isIdle", true);
    }


    public void SetRunAnim()
    {
        AnimHandler.SetBool("isIdle", false);
        AnimHandler.SetBool("isWalking", false);
        AnimHandler.SetBool("isRunning", true);
    }
    public void SetWalkAnim()
    {
        AnimHandler.SetBool("isIdle", false);
        AnimHandler.SetBool("isRunning", false);
        AnimHandler.SetBool("isWalking", true);
    }

    public void SetDieAnim(bool isDying)
    {
        AnimHandler.SetBool("isIdle", !isDying);
        AnimHandler.SetBool("isDying", isDying);
    }


    public void SetSideJumpRunningAnim()
    {
        AnimHandler.SetBool("isIdle", false);
        AnimHandler.SetBool("isRunning", false);
        AnimHandler.SetBool("isSideJumping", true);
    }

    public void SetSideJumpIdleAnim()
    {
        AnimHandler.SetBool("isIdle", false);
        AnimHandler.SetBool("isSideJumping", true);
    }

    public void SetSideJumpWalkingAnim()
    {
        AnimHandler.SetBool("isIdle", false);
        AnimHandler.SetBool("isWalking", false);
        AnimHandler.SetBool("isSideJumping", true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.CompareTag("Level"))
        //    CanJump = true;
    }

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Level"))
    //        CanJump = false;
    //}
}

