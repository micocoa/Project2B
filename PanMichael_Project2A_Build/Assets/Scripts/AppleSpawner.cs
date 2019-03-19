using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    public GameObject bas;
    public GameObject prefab;
    public float speed;
    public float leftEdge =855f;
    public float rightEdge =855f;
    public float p = 0.5f;
    public bool oneTime = false;
    
    void Awake()
    {
        bas = GameObject.Find("baskets");
    }


    // Update is called once per frame
    void Update()
    {
        if (bas.GetComponent<Basket>().game)
        {
            speed = Random.Range(-50f, 50f);
            Vector2 pos = transform.position;
            pos.x += speed * Time.deltaTime;
            transform.position = pos;
            if (pos.x < -leftEdge)
            {
                speed = Mathf.Abs(speed);
            }
            else if (pos.x > rightEdge)
            {
                speed = -Mathf.Abs(speed);
            }
            if (!oneTime)
            {
                InvokeRepeating("Spawn", 1.5f, 1.5f);
                oneTime = true;

            }
        }
        else if (bas.GetComponent<Basket>().over)
        {
            Vector2 o = new Vector2(0f, 20f);
            this.transform.position = o;
            CancelInvoke("Spawn");
            oneTime = false;
        }

    }

    void FixedUpdate()
    {
        if (bas.GetComponent<Basket>().game)
        {
            if (Random.value <= p)
            {
                speed *= -1;
            }
        }
    }

     void Spawn()
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
}
