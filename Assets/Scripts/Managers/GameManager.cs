﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    public Player player;

    //for acheivement
    public List<int> eventLog = new List<int>();
    public List<Task> taskLog = new List<Task>();

    //for lecture choice score
    public static int[] lectureChoiceScore = new int[5];
    
    //for lecture Application score
    public static int[] lectureApplicationScore = new int[5];

    //for lecture supplement scene, schedule manager
    public Study[] studyResultArray = new Study[5];

    //public LectureList lectureList = new LectureList();

    public const float TASK_TIME = 4f;


    void Awake()
    {
        player = new Player();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
