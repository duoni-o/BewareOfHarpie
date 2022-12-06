using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryKey : MonoBehaviour
{
    public bool keyDown;
    public GameObject inventory;

    // Start is called before the first frame update
    void Start()
    {
        keyDown = false;
        print(inventory.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        //인벤토리 활성
        if(Input.GetKeyDown("z")){
            keyDown = !keyDown;
        }

        InventoryEnable(keyDown);

    }

    void InventoryEnable(bool enable)
    {
        inventory.SetActive(enable);
    }
}
