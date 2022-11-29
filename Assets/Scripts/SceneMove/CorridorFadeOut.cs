using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class CorridorFadeOut : MonoBehaviour
{
    public Image image; //검은색 화면

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FadeCoroutine(){
        
        float fadeCount = 1.0f; //처음 알파값
        while(fadeCount > 0.0f) { //알파 최대값 1.0까지 반복
            fadeCount -= 0.05f;
            yield return new WaitForSeconds(0.01f); //0.01초마다 실행
            image.color = new Color(0,0,0,fadeCount); //해당 변수값으로 알파값 지정
        }
        
    }
}
