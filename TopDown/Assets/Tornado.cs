using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour
{
    Rigidbody2D rg;
    [SerializeField] float x;
    [SerializeField] float y;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Speed();
    }

    void Speed()
    {
        rg.velocity = new Vector2(transform.position.x *Time.deltaTime*20, transform.position.y*Time.deltaTime*-1*20);
    }
}
