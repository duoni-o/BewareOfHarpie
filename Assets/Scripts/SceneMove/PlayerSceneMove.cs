using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class PlayerSceneMove : MonoBehaviour
{
    Scene scene;
    public Image image; //검은색 화면
    PlayerDataSave playerDataSave;

    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene(); 

        if (scene.name == "03. Dump")
        {
            playerDataSave = GameObject.Find("Player_broken_jump").GetComponent<PlayerDataSave>();
        }
        else
        {
            playerDataSave = GameObject.Find("Player_broken_noJump").GetComponent<PlayerDataSave>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Door") {
            if (PlayerPrefs.HasKey("GetKey")){
               
                if(scene.name == "03. Dump"){
                    StartCoroutine(FadeCoroutine("04. Corridor"));
                    
                }
            }

            if (scene.name == "04. Corridor")
            {
                SceneManager.LoadScene("05. HarpieRoom");
            }
        }
    }

    IEnumerator FadeCoroutine(string SceneName){
        
        float fadeCount = 0; //처음 알파값
        while(fadeCount < 1.0f) { //알파 최대값 1.0까지 반복
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.01f); //0.01초마다 실행
            image.color = new Color(0,0,0,fadeCount); //해당 변수값으로 알파값 지정
        }
        SceneManager.LoadScene(SceneName);
        //데이터 저장
        playerDataSave.Save(scene.name);
    }
}
