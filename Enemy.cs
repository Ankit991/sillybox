using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (transform.position.x <= -14)
        {
            Destroy(gameObject);
        }
    }
  
}
