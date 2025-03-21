using System;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Fight
{
    private Inhabitant attacker;
    private Inhabitant defender;


    public Fight()
    {
        int roll = UnityEngine.Random.Range(0, 20) + 1;
        if (roll <= 10)
        {
            Debug.Log("Monster goes first");
            this.attacker = Core.theMonster;
            this.defender = Core.thePlayer;

        }
        else
        {
            Debug.Log("Player goes first");
            this.attacker = Core.thePlayer;
            this.defender = Core.theMonster;
        }

    }

    public void startFight()
    {
        Debug.Log($"The first attacker is {attacker.getName()}, they have {attacker.getCurrHP()} health and they have the Armor Class: {attacker.getAC()}");
        Debug.Log($"The first defender is {defender.getName()}, they have {defender.getCurrHP()} health and they have the Armor Class: {defender.getAC()}");

        while (true)
        {

            int mayAttack = UnityEngine.Random.Range(10, 20);
            if (mayAttack >= defender.getAC())
            {
                int damage = UnityEngine.Random.Range(5, 15);
                defender.takeDamage(damage);

                Debug.Log($"{attacker.getName()} attacked " +
                    $"{defender.getName()} and {defender.getName()} " +
                    $"took {damage} damage from their health");

                

                if (defender.isDead())
                {
                    Debug.Log($"{defender.getName()} has died. Thus, {attacker.getName()} is the winner!!");
                    break;
                }
                Debug.Log($"{defender.getName()} is now at {defender.getCurrHP()} HP ");

            }
            else
            {
                Debug.Log($"{attacker.getName()} has missed his attack!");

            }


            Inhabitant k = attacker;
            attacker = defender;
            defender = k;
        }
        //should have the attacker and defender fight each until one of them dies.
        //the attacker and defender should alternate between each fight round and
        //the one who goes first was determined in the constructor.

        //use core
        //print out the back and forth attack
        //basically what we did in death match
    }
}