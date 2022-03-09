using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Transform projectileSpawnPoint;
    Rigidbody2D m_Rigidbody;
    public float m_Speed = 5f;
    public bool facingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Instantiate(Resources.Load("Projectile"), projectileSpawnPoint.transform.position, Quaternion.identity);
        }
    }

    void FixedUpdate()
    {
        //Store user input as a movement vector
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 m_Input = new Vector3(h, 0, 0);
        if (h > 0)
        {
            gameObject.transform.localScale =  new Vector3(1, 1, 1);
        }
        else if(h < 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }

        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        m_Rigidbody.MovePosition(transform.position + m_Input * Time.deltaTime * m_Speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (!collision.gameObject.GetComponent<Animator>().GetBool("dead")) 
            {
                FindObjectOfType<GameController>().score = 0;
                SceneManager.LoadScene("LevelOne");
            }
        } 
    }
}
