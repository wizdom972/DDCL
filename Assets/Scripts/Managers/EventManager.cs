﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : SingletonBehaviour<EventManager>
{

    public GameObject eventPopUpWindow;

    //miniGameList[0] => Bulb Catch
    //miniGameList[1] => correct button clicker
    //miniGameList[2] => 이지선다 퀴즈 미로
    //miniGameList[3] => 뒤집힌 카드 맞추기
    //miniGameList[4] => 파이프 게임
    public List<GameObject> miniGameList = new List<GameObject>();

    public int miniGameResult;

    //bulb catch
    public GameObject bulb;
    public Button buttonBulbCatch;

    public float bulbSpeed = 1000f;
    public float direction = 1f;

    public float[] bulbMiniGameScore = new float[3];

    public int bulbGameNum = 0;

    public bool isBulbGamePlaying = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (bulb.transform.localPosition.x > 350f
            || bulb.transform.localPosition.x < -350f)
        {
            direction *= -1;
        }

        if(isBulbGamePlaying)
        {
            bulb.transform.Translate(Vector3.right * direction * bulbSpeed * Time.deltaTime);
        }
    }

    public void InsertEvent()
    {

    }


    public void ApplyEventEffect(string methodName)
    {
        Invoke(methodName, 0f);
    }

    //Event method

    public void MiniGameBulbCatch()
    {
        miniGameList[0].SetActive(true);

        direction = 1f;

        bulb.transform.localPosition = new Vector2(-350f, 424f);

        isBulbGamePlaying = true;

        if(bulbGameNum > 0)
        {
            return;
        }

        buttonBulbCatch.onClick.AddListener(() => OnBulbCatchGameButtonClick());
    }

    public void OnBulbCatchGameButtonClick()
    {
        Debug.Log("bulbGameNum: " + bulbGameNum);

        if(bulbGameNum < 3)
        {
            if (bulb.transform.localPosition.x >= -60 && bulb.transform.localPosition.x <= 60)
            {
                bulbMiniGameScore[bulbGameNum] = 4f;
            }
            else if (bulb.transform.localPosition.x >= -160 && bulb.transform.localPosition.x <= 160)
            {
                bulbMiniGameScore[bulbGameNum] = 2f;
            }
            else
            {
                bulbMiniGameScore[bulbGameNum] = 0f;
            }

            bulbGameNum++;

            if(bulbGameNum < 2)
            {
                MiniGameBulbCatch();
            }
            
        }
        else
        {
            float result = 0;

            for(int i = 0; i < 3; i++)
            {
                result += bulbMiniGameScore[i];
            }

            if(result >= 10)
            {
                miniGameResult = 0;
            }
            else if(result >= 8)
            {
                miniGameResult = 1;
            }
            else
            {
                miniGameResult = 2;
            }

            eventPopUpWindow.GetComponent<EventPopUp>().InitResult();
        }
    }
}
