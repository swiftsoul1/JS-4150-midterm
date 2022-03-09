using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileController : MonoBehaviour
{
    [SerializeField]
    private float speed = 2f;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {

        
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void OnBecameVisible()
    {
        GameObject temp = GameObject.Find("Player_Sprite");
        Transform spriteTransform = temp.GetComponent<Transform>();
        if (spriteTransform.localScale.x == -1)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
            rb2d.velocity = Vector2.left * speed;
        }
        else
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            rb2d.velocity = Vector2.right * speed;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
