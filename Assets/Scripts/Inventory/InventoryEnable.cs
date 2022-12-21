/*
 * 작성자 : 공서은
 * 아이템을 획득하면 해당 인벤토리 내의 아이템 이미지의 투명도를 1로 설정
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryEnable : MonoBehaviour
{
    Transform[] myChildren;
    

    public void Inventory(string slotName)
    {
        myChildren = this.GetComponentsInChildren<Transform>();

        foreach (Transform child in myChildren)
        {
           
            if (child.name == slotName)
            {
                GameObject childImg = child.gameObject;

                Color color = childImg.GetComponent<Image>().color;
                color.a = 1.0f; //0으로 설정한 투명도를 1로 설정

                childImg.GetComponent<Image>().color = color;
            }
        }
    }
}
