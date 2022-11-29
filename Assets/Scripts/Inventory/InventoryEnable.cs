using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryEnable : MonoBehaviour
{
    Transform[] myChildren;
    

    // Start is called before the first frame update
    void Start()
    {
        myChildren = this.GetComponentsInChildren<Transform>();
    }

    public void Inventory(string slotName)
    { 

        foreach (Transform child in myChildren)
        {
           
            if (child.name == slotName)
            {
                GameObject childImg = child.gameObject;

                Color color = childImg.GetComponent<Image>().color;
                color.a = 1.0f;

                childImg.GetComponent<Image>().color = color;
            }
        }
    }
}
