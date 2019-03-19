using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    [Header("References")]
    public float speed = 10000f;
    public static float edge = -25f;
    public GameObject bas;
    // Start is called before the first frame update
    void Awake()
    {
        bas = GameObject.Find("baskets");
    }

    // Update is called once per frame
    void Update()
    {
        if (bas.GetComponent<Basket>().game)
        {
            Vector2 pos = this.transform.position;
            pos.y -= speed * Time.deltaTime;
            transform.position = pos;
            if (pos.y <= edge)
            {
                Destroy(gameObject);
                bas.GetComponent<Basket>().currentLife--;
            }
        }
    }
}
