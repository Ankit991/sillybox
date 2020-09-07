using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D Rb;
    public int force1;
    int force = 20;
    GameManager gamemanager;
    private Animator anim;
    public Transform Enemy;
    public ParticleSystem playerparticle;
    public GameObject[] envi;
    public ParticleSystem dust;
  
    // Start is called before the first frame update
    private void Awake()
    {
        for (int i = 0; i < envi.Length; i++)
        {
            envi[i].GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }
    }
    void Start()
    {
      
        Rb = GetComponent<Rigidbody2D>();
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (!gamemanager.isgameover)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerparticle.Play();
                Rb.AddForce(Vector2.up * force);
                anim.SetTrigger("jump");
                Soundmanager.PlaySound("jump");
            }
            if (Input.GetKey(KeyCode.S))
            {
                Rb.AddForce(Vector2.down * force1);
            }
        }
      
    }
    #region when playertouchground
    public void touchingUp()
    {
        
        if (!gamemanager.isgameover)
        {
                playerparticle.Play();
                Rb.AddForce(Vector2.up * force);
                anim.SetTrigger("jump");
                Soundmanager.PlaySound("jump");
        
          
        }
    }
    public void touchingdown()
    {
       
        Rb.AddForce(Vector2.down * force1);
        
    }
    #endregion
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            gamemanager.GameOver();
           
            Soundmanager.PlaySound("hurt");
        }
        if (collision.gameObject.CompareTag("envedge"))
        {
            dust.Play();
        }
    }
}
