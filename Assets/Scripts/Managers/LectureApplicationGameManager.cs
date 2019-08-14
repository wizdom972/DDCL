﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LectureApplicationGameManager : MonoBehaviour
{
    public Button buttonApplication;
    public Image fire;
    public Sprite[] fireSprite = new Sprite[4];

    public const int GAME_TIME = 2;
    public float countTime = GAME_TIME;
    public float beforeGameTime = 3;
    public int lectureCount;

    public bool start=false;

    private int _clickCount;
    private int applicationScore;
    private int _fireLevel;
    private int _presentLecture;

    // Start is called before the first frame update
    void Start()
    {
        fire.GetComponent<Image>().sprite = fireSprite[0];
    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.deltaTime;

        if (start == false)
        {
            beforeGameTime -= time;
            if(beforeGameTime <= 0)
            {
                start = true;
                Debug.Log("start!");

                buttonApplication.onClick.AddListener(AddApplicationCount);
            }

        }

        else if (start == true)
        {
            countTime -= time;
            if (countTime <= 0)
                ApplicationEnd(lectureCount);

            ChangeSpriteFire(_clickCount, lectureCount);
        }


        if (lectureCount == 5)
        {
            SceneManager.LoadScene(3);
        }
    }

    private void AddApplicationCount()
    {
        _clickCount++;
    }
    


    private void ApplicationEnd(int lecture)
    {
        //if game time is over, go lecture result scene
        //and save score in GameManage
        if (_clickCount >= 23)
            applicationScore = 10;
        else if (_clickCount >=19&&_clickCount<23)
            applicationScore = 7;
        else if (_clickCount >= 15&&_clickCount<19)
            applicationScore = 4;
        else
            applicationScore = 1;

        Debug.Log(lecture+" "+_clickCount+" "+applicationScore);

        
        GameManager.lectureApplicationScore[lecture] = applicationScore;

        lectureCount++;
        countTime = 2;
        _clickCount = 0;
    }

    private void ChangeSpriteFire(int countClick,int countLecture)
    {
        if (countLecture != _presentLecture)
        {
            if (countClick >= 19)
            {
                _fireLevel++;
                fire.GetComponent<Image>().sprite = fireSprite[_fireLevel];
                _presentLecture = countLecture;
            }
        }
    }
}
 