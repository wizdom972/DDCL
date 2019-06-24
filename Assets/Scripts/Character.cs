﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    //character's stat
    private float _intelligence;

    private float _maxStamina;
    private float _curStamina;

    private float _maxFassion;
    private float _curFassion;

    private float _maxSociability;
    private float _curSociability;


    public float Intelli
    {
        get { return _intelligence; }

        set
        {
            _intelligence = value;
        }
    }

    public float MaxStamina
    {
        get { return _maxStamina; }

        set
        {
            _maxStamina = value;
        }
    }

    public float CurStamina
    {
        get { return _curStamina; }

        set
        {
            _curStamina = value;
        }
    }

    public float MaxFassion
    {
        get { return _maxFassion; }

        set
        {
            _maxFassion = value;
        }
    }

    public float CurFassion
    {
        get { return _curFassion; }

        set
        {
            _curFassion = value;
        }
    }

    public float MaxSocial
    {
        get { return _maxSociability; }

        set
        {
            _maxSociability = value;
        }
    }

    public float CurSocial
    {
        get { return _curSociability; }

        set
        {
            _curSociability = value;
        }
    }
}
