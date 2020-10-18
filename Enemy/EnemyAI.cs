using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public bool isPursuitModeOn = true;


    public float Speed = 1f;
    public float Distance;
    public Transform Player;
    public bool face = true;

    public Animator AnimHandler;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Distance = Vector2.Distance(Player.transform.position, transform.position);

        // Flip

        if ((Player.transform.position.x < this.transform.position.x) && !face)
        {
            Flip();
        }
        else if ((Player.transform.position.x > this.transform.position.x) && face)
        {
            Flip();
        }

        if (isPursuitModeOn && Distance > 2.8f)
        {
            if (Player.transform.position.x < this.transform.position.x)
            {
                transform.Translate(new Vector2(-Speed * Time.deltaTime, 0));
                AnimHandler.SetBool("isWalking", true);
                AnimHandler.SetBool("isIdle", false);
            }
            else if (Player.transform.position.x > this.transform.position.x)
            {
                transform.Translate(new Vector2(Speed * Time.deltaTime, 0));
                AnimHandler.SetBool("isWalking", true);
                AnimHandler.SetBool("isIdle", false);
            }    
        }
        else
        {
            AnimHandler.SetBool("isWalking", false);
            AnimHandler.SetBool("isIdle", true);
        }

        //transform.Translate(new Vector2(Vector2.right * Time.deltaTime * 3f));
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.CompareTag("Player"))
        //{
        //    isPursuitModeOn = true;
        //}
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if (collision.gameObject.CompareTag("Player"))
        //{
        //    isPursuitModeOn = false;
        //}
    }

    public void Flip()
    {
        face = !face;
        Vector2 scale = this.transform.localScale;
        scale.x *= -1;
        this.transform.localScale = scale;
    }

}
