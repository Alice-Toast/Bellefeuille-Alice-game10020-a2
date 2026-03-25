using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] ConnectedButtons;
    bool isdooropen;
    void Start()
    {
        foreach (var button in ConnectedButtons)
        {
            button.GetComponent<button>().onClick.AddListener(doorToggle);
        }
        
    }



    void doorToggle(bool open)
    {
        isdooropen = open;
        if (open)
        {
            this.GetComponent<SpriteRenderer>().color = Color.white;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().color = Color.gray;
        }
    }

    
    // Update is called once per frame
    void Update()
    {
        
    }
}
