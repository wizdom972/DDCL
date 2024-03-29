﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public string name;

    //character's stat
    protected float _intelligence;

    protected float _maxStamina;
    protected float _curStamina;

    protected float _maxFassion;
    protected float _curFassion;

    protected float _maxSociability;
    protected float _curSociability;

    //character's semester start date
    protected int _startSemester;
    
    //each stat's max value
    protected const float MAX_INTELLI = 200f;
    protected const float MAX_STAMINA = 200f;
    protected const float MAX_FASSION = 200f;
    protected const float MAX_SOCIAL = 200f;


    public float Intelli
    {
        get { return _intelligence; }

        set
        {
            _intelligence = value;

            //don't let exceed maximum
            if(_intelligence > MAX_INTELLI)
            {
                _intelligence = MAX_INTELLI;
            }
        }
    }

    public float MaxStamina
    {
        get { return _maxStamina; }

        set
        {
            _maxStamina = value;

            //don't let exceed maximum
            if (_maxStamina > MAX_STAMINA)
            {
                _maxStamina = MAX_STAMINA;
            }
        }
    }

    public float CurStamina
    {
        get { return _curStamina; }

        set
        {
            _curStamina = value;

            //current value can't exceed max value
            if(_curStamina > _maxStamina)
            {
                _curStamina = _maxStamina;
            }
        }
    }

    public float MaxFassion
    {
        get { return _maxFassion; }

        set
        {
            _maxFassion = value;

            //don't let exceed maximum
            if (_maxFassion > MAX_FASSION)
            {
                _maxFassion = MAX_FASSION;
            }
        }
    }

    public float CurFassion
    {
        get { return _curFassion; }

        set
        {
            _curFassion = value;

            //current value can't exceed max value
            if (_curFassion > _maxFassion)
            {
                _curFassion = _maxFassion;
            }
        }
    }

    public float MaxSocial
    {
        get { return _maxSociability; }

        set
        {
            _maxSociability = value;

            //don't let exceed maximum
            if (_maxSociability > MAX_SOCIAL)
            {
                _maxSociability = MAX_SOCIAL;
            }
        }
    }

    public float CurSocial
    {
        get { return _curSociability; }

        set
        {
            _curSociability = value;

            //current value can't exceed max value
            if (_curSociability > _maxSociability)
            {
                _curSociability = _maxSociability;
            }
        }
    }

    public int StartSemester
    {
        get { return _startSemester; }

        set
        {
            _startSemester = value;
        }
    }

    
    public void ChangeStat(string whichStat, float changeValue)
    {
        switch (whichStat)
        {
            case ("intell"):
                this.Intelli += changeValue;
                break;
            case ("fassion"):
                this.CurFassion += changeValue;
                break;
            case ("stamina"):
                this.CurStamina += changeValue;
                break;
            case ("social"):
                _curSociability += changeValue;
                break;
        }
    }

    public void ChangeStat(Task task)
    {
        //Debug.Log("stamina: " + task.staminaVal + "social: " + task.socialVal);

        this.CurStamina += task.staminaVal;
        this.CurSocial += task.socialVal;
        this.CurFassion += task.fassionVal;
    }
    
}

public class Newbie : Character
{
    public Newbie()
    {
        Character character = new Character();

        //set character name
        this.name = "뉴비";

        //set character stat
        this._intelligence = Random.Range(125, 151); 
        this._curStamina = Random.Range(115, 191);
        this._curFassion = Random.Range(80, 110);
        this._curSociability = Random.Range(50, 176);

        this._maxFassion = 110;
        this._maxSociability = 176;
        this._maxStamina = 191;

        //set character start semester
        this._startSemester = 1;
    }
}