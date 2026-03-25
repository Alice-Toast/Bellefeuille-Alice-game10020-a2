using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class characterMove : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ArrowPrefab;
    public float speed = 3;
    private Rigidbody2D rb;
    bool arrowFired = false;
    float timeRemaining = 0;
    public Vector2 facingdDirection = new Vector2(1,0);
    public Sprite CharacterIdle;
    public Sprite CharacterMoveR;
    public Sprite CharacterMoveUp;
    private SpriteRenderer sr;
    private Vector2 direction = Vector2.down;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        sr = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(h * speed, y*speed);
        float absH = Mathf.Abs(h);
        float absY = Mathf.Abs(y);
        if (absH > 0.3 || absY > 0.3)
        {
            facingdDirection = new Vector2(h, y);
            if(absH > absY)
            {
                sr.sprite = CharacterMoveR;
                if (h > 0)
                {
                    sr.flipX = false;
                    direction = Vector2.right;
                }
                else
                {
                    sr.flipX = true;
                    direction = Vector2.left;
                }
            }
            else
            {
                if (y > 0)
                {
                    sr.sprite = CharacterMoveUp;
                    direction = Vector2.up;
                }
                else
                {
                    sr.sprite = CharacterIdle;
                    direction = Vector2.down;
                }
            }
        }
        if (timeRemaining <= 0)
        {
            if (Input.GetKey(KeyCode.E))
            {
                timeRemaining = 1;
                ArrowPrefab.GetComponent<Arrow>().direction = direction;

                Instantiate(ArrowPrefab, transform.position, quaternion.identity);

            }
        }
        else
        {
            timeRemaining -= Time.deltaTime;
        }
        
        
    }
}
