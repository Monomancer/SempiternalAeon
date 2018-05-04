using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player{

    public int Coins
    {
        get
        {
            return PlayerPrefs.GetInt("coins");
        }
        set
        {
            PlayerPrefs.SetInt("coins", value);
        }
    }

    public int Level
    {
        get
        {
            return PlayerPrefs.GetInt("level");
        }
        set
        {
            PlayerPrefs.SetInt("level", value);
        }
    }


    public float Exp
    {
        get
        {
            return PlayerPrefs.GetFloat("exp");
        }
        set
        {
            PlayerPrefs.SetFloat("exp", value);
        }
    }

    public int MaxHealth
    {
        get
        {
            return PlayerPrefs.GetInt("maxHealth");
        }
        set
        {
            PlayerPrefs.SetInt("maxHealth", value);
        }
    }
    public int CurrentHealth
    {
        get
        {
            return PlayerPrefs.GetInt("currentHealth");
        }
        set
        {
            PlayerPrefs.SetInt("currentHealth", value);
        }
    }
    public int Damage
    {
        get
        {
            return PlayerPrefs.GetInt("damage");
        }
        set
        {
            PlayerPrefs.SetInt("damage", Damage);
        }
    }




    public int BatsKilled
    {
        get
        {
            return PlayerPrefs.GetInt("batsKilled");
        }
        set
        {
            if(QuestType == "monster")
            {
                QuestProgress++;
            }
            PlayerPrefs.SetInt("batsKilled", value);
        }
    }

    public string QuestType
    {
        get
        {
            return PlayerPrefs.GetString("questType");
        }
        set
        {
            PlayerPrefs.SetString("questType", value);
        }

    }

    public int QuestsCompleted
    {
        get
        {
            return PlayerPrefs.GetInt("questsCompleted");
        }
        set
        {
            PlayerPrefs.SetInt("questsCompleted", value);
        }
    }

    public int QuestProgress
    {
        get
        {
            return PlayerPrefs.GetInt("questProgress");
        }
        set
        {
            PlayerPrefs.SetInt("questProgress", value);
        }
    }




}
