using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playermovement : MonoBehaviour {

    // Use this for initialization
    public Rigidbody2D rb;
    public Animator animator;
    public LayerMask ground;
    public Collider2D coller;
    public AudioSource jumpAudio, hurtAudio, maskAudio, hitAudio,deadAudio;
    
    public float jumpforce = 10f; 
    public float speed=10f;
    public int mask = 0;
    public Text masknum;
    public int alc = 0;
    public Text alcnum;
    public GameObject bell;
    public GameObject body;
    public GameObject atkword;
    public GameObject alcohol;
    bool atk=false;
    
    int alctime=0;
    

    void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        
        if (!animator.GetBool("hurt"))
        {
             movement();
        }
       
        Switchanim();

    }
    //腳色移動
    void movement()
    {
        float horizontalmove;
        horizontalmove=Input.GetAxis("Horizontal");
        //取得腳色移動方向
        //-1<值<1 可使角色轉向不那麼突然
        float direction;
        //取得腳色移動方向 用於操控圖片方向
        direction = Input.GetAxisRaw("Horizontal");
        if (horizontalmove !=0 )
        {
            rb.velocity = new Vector2(horizontalmove * speed*Time.deltaTime, rb.velocity.y);
            //改變角色速度 使用Time.deltaTime讓它在每部電腦呈現效果相同
            animator.SetFloat("running", Math.Abs(direction));
            //用於動畫控制，使animator得到running數值改變
        }
        if (direction != 0 )//表示移動中
        {
            transform.localScale = new Vector3(direction, 1, 1);
            //改變圖片方向
        }
        //腳色跳躍
        if (Input.GetButtonDown("Jump") && coller.IsTouchingLayers(ground))//限制只能於地面跳躍
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpforce * Time.deltaTime);
            jumpAudio.Play();
            animator.SetBool("jumping",true);
            //用於動畫控制，使animator得到jumping數值改變
            //進入jumping動畫
        }
        if (Input.GetKeyDown(KeyCode.W)&& alc>0)
        {
            alc--;
            alcnum.text = (alc.ToString());
            hitAudio.Play();
            GameObject Bell= Instantiate(bell,transform.position,transform.rotation);
            Bell.transform.SetParent(transform);
            Bell.transform.localPosition=new Vector3 (15,0,0);
            Bell.transform.localScale=new Vector3(1,1,1);
            if (alctime>=2 && alc==0)
            {
                Vector3 posi=new Vector3(113.9f,60.1f,0);
                Instantiate(alcohol,posi,transform.rotation);
            }
        {
            
        }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            hurtAudio.Play();
            restart();
        }
         if (Input.GetKeyDown(KeyCode.C))
        {
            deadAudio.Play();
            Invoke("clean",0.5f);
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
                Time.timeScale = 0;
        }
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
                Time.timeScale = 1;
        }

    }
    void Switchanim()//動畫切換
    {
        
        animator.SetBool("idle", false);
        if (animator.GetBool("jumping"))
        {
            if(rb.velocity.y<=0)
            {
                animator.SetBool("jumping", false);
                animator.SetBool("falling", true);
                //腳色掉落啟動掉落動畫
            }
        }
        else if(animator.GetBool("hurt"))
        {
            
            if(Math.Abs(rb.velocity.x)<1f)
            {
                
                animator.SetBool("hurt", false);
                animator.SetBool("idle", true);
            }
        } 

        if (coller.IsTouchingLayers(ground))
        {
            animator.SetBool("falling", false);
            animator.SetBool("idle", true);
            //回歸初始狀態
        }
        if (rb.velocity.y < 0)
        {
            animator.SetBool("jumping", false);
            animator.SetBool("falling", true);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)//口罩蒐集判定
    {
     if (collision.tag=="mask")
        {
            maskAudio.Play();
            Destroy(collision.gameObject);
            mask++;
            masknum.text = (mask.ToString());
        }
    if (collision.tag=="alcohol")
        {
            
            alctime++;
            Destroy(collision.gameObject);
            maskAudio.Play();
            alc++;
            alcnum.text = (alc.ToString());
            if(alctime==1)
            {
                Instantiate(atkword,transform.position,transform.rotation);
            }
        }
    if (collision.tag=="dead")
        {
           deadAudio.Play();
           Invoke("clean",0.5f);
           Console.WriteLine("dead for deadline");
        }
    
    }
    private void OnCollisionEnter2D(Collision2D collision)//病毒判定
    {
        if (collision.gameObject.tag=="enemy")
        {
            
            if (transform.position.x <collision.gameObject.transform.position.x)
            {
                rb.velocity=new Vector2(-10,rb.velocity.y);
                animator.SetFloat("running",0.11f);
                animator.SetBool("hurt", true);
                hurtAudio.Play();
            }
            if (transform.position.x >collision.gameObject.transform.position.x)
            {
                rb.velocity=new Vector2(10,rb.velocity.y);
                animator.SetFloat("running",0.11f); 
                animator.SetBool("hurt", true);
                hurtAudio.Play();

            }
            mask--;
            if (mask<0)
            {
                restart();
                 Console.WriteLine("dead for mask");
            }
            masknum.text = (mask.ToString());
        }
    }
    void restart()
    {
        Instantiate(body,transform.position,transform.rotation);
        Instantiate(body,transform.position,transform.rotation);
        Instantiate(body,transform.position,transform.rotation);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void clean()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
