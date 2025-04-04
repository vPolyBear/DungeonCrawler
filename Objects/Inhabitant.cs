using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class Inhabitant
{
    protected int currHp;
    protected int maxHp;
    protected int ac;
    protected string name;

    public Inhabitant(string name)
    {
        this.name = name;
        this.maxHp = UnityEngine.Random.Range(30, 50);
        this.currHp = this.maxHp;
        this.ac = UnityEngine.Random.Range(10, 20);
    }

    public String getName()
    {
        return this.name;
    }
    public int getCurrHP()
    {
        if (this.currHp < 0)
        {
            this.currHp = 0;
        }
        return this.currHp;
        
    }

    public int getMaxHp()
    {
        
        return this.maxHp;

    }

    public int getAC()
    {
        return this.ac;
    }

    public void takeDamage(int damage)
    {
        this.currHp = this.currHp - damage;
    }
    public bool isDead()
    {
        return this.currHp <= 0;
    }

    public void setCurrHp(int hp)
    {
        this.currHp = hp;
    }

}