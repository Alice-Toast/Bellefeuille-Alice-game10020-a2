using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class button : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public bool active;
    private Color colour;
    public UnityEvent<bool> onClick;
    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeStates()
    {
        if (active)
        {
            colour = Color.green;
        }
        else
        {
            colour = Color.red;
        }
        onClick.Invoke(active);
        
        this.GetComponent<SpriteRenderer>().color = colour;
    }
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("collision");
        if(!active)
        {
            if (collision.tag == "Player" || collision.tag == "box")
            {
                active = true;
                ChangeStates();
            }
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(active)
        {
            if (collision.tag == "Player" || collision.tag == "box")
            {
                active = false;
                ChangeStates();
            }
        }
        
    }
}
