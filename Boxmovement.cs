using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxmovement : MonoBehaviour
{
    
    public bool isdestroy;
    public float speed;
    GameManager gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gamemanager.isgameover)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);

        }
        #region this setion is set on/of of boxmovement
        if (transform.position.x <= -65)
        {
            this.gameObject.SetActive(false);
            isdestroy = true;
        }
        if (isdestroy)
        {
            this.gameObject.SetActive(true);
            transform.position = new Vector2(Random.Range(10, 10.5f), 0);
            isdestroy = false;
        }
        #endregion

        if (gamemanager.scorePoint>=40)
        {
            speed = 6;
        }
        if (gamemanager.scorePoint >= 70)
        {
            speed = 6.5f;
        }
        if (gamemanager.scorePoint >= 110)
        {
            speed = 7;
        }
       
    }

   
}
