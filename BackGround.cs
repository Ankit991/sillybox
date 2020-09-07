using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    // Start is called before the first frame update
    bool isdestroy;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * 4 * Time.deltaTime);
        if (transform.position.x <= -19.5f)
        {
            this.gameObject.SetActive(false);
            isdestroy = true;
        }
        if (isdestroy)
        {
            this.gameObject.SetActive(true);
            transform.position = new Vector3(18.6f, -6,32);
            isdestroy = false;
        }
    }
}
