using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class SimpleMoveController : MonoBehaviour
{
    public Animator myAnimator;
    public int speed = 5;
    private Rigidbody2D rb;
    public float jumpForce = 5f;
    private bool isgrounded;
    

    private void Start()
    {
        myAnimator.SetBool("move", false);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxis("Horizontal");//키보드의 입력을 받아서 (좌우 화살표)

        if (direction > 0) // 오른쪽 화살표 or D 키보드
        {
            transform.localScale = new Vector3(1, 1, 1);
            myAnimator.SetBool("move", true);
        }
        else if (direction < 0) // 왼쪽 화살표 or 
        {
            transform.localScale = new Vector3(-1, 1, 1);
            myAnimator.SetBool("move", true);
        }
        else
        {
            myAnimator.SetBool("move", false);
        }
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isgrounded == true)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        isgrounded = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isgrounded = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Door")
            SceneManager.LoadScene("Map1");

        if (collision.name == "Door2")
            SceneManager.LoadScene("Map2");

        if (collision.name == "Door3")
            SceneManager.LoadScene("Map3");


    }
   
      
    }

   
