using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : MonoBehaviour
{
    float speed = 2f;
    private Rigidbody2D rb;
    private Vector2 dir;
    private int facing;
    private Transform transform;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        transform = GetComponent<Transform>();
        Debug.Log(transform.localPosition.x.ToString());
        if (2.5 < transform.position.x)
        {
            dir = new Vector2(-1 * speed, rb.velocity.y);
            facing = 3;
        }
        else
        {
            dir = new Vector2(1 * speed, rb.velocity.y);
            facing = -3;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            collision.gameObject.SetActive(false);
            bool dead = anim.GetBool("dead");
            if (!dead)
            {
                FindObjectOfType<GameController>().UpdateScore();
                anim.SetBool("dead", true);
                
            }
        }
    }

    void FixedUpdate()
    {
        bool dead = anim.GetBool("dead");
        if (!dead)
        {
            transform = GetComponent<Transform>();
            rb.velocity = dir;
            gameObject.transform.localScale = new Vector3(facing, 4, 1);
            
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("DeadSkeleton")) 
        { 
            Destroy(gameObject);
        }

    }
}
