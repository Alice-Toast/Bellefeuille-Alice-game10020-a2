using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class lightninggate : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] ConnectedButtons;
    int buttonsOn;
    void Start()
    {
        foreach(var button in ConnectedButtons)
        {
            button.GetComponent<button>().onClick.AddListener(GateToggle);
        }
        
    }



    public void GateToggle(bool state)
    {
        if (state)
        {
            buttonsOn++;
        }
        else
        {
            buttonsOn--;
        }
        bool newState = false;
        if (buttonsOn > 0)
        {
            newState = true;
        }
        this.GetComponent<Collider2D>().enabled = !newState;
        this.GetComponent<SpriteRenderer>().enabled = !newState;

    }
}
