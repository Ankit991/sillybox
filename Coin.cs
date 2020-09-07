using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    GameManager gamemanager;
   
    int speed = 7;
    // Start is called before the first frame update
    void Start()
    {
      
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);


        if (transform.position.x <= -10)
        {
            Destroy(this.gameObject);
        }
    }
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
          
            Destroy(this.gameObject);
            gamemanager.coinpoint += 1;
            Soundmanager.PlaySound("coin");
           
        }
    }
   
}
