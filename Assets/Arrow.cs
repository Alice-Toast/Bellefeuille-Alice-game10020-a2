using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 direction;
    public float speed = 3;
    // make it work
    void Start()
    {
        Quaternion trueRotation = Quaternion.Euler(0f, 0f, 0f);
        if (direction == Vector2.left)
        {
            trueRotation = Quaternion.AngleAxis(180, Vector3.forward);
        }
        else if (direction == Vector2.up)
        {
            trueRotation = Quaternion.AngleAxis(90, Vector3.forward);
        }
        else if (direction == Vector2.down)
        {
            trueRotation = Quaternion.AngleAxis(270, Vector3.forward);
        }
        transform.rotation = trueRotation;
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody2D>().velocity = (direction * speed);
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "box")
        {
            collision.otherRigidbody.velocity = this.GetComponent<Rigidbody2D>().velocity;
        }
        Destroy(gameObject);
    }
}
