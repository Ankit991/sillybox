using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxmovement1 : MonoBehaviour
{
    
    public bool isdestroy;
    public float speed;
    public GameObject[] envi;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < envi.Length; i++)
        {
            envi[i].GetComponent<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
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
       
    }
   
}
