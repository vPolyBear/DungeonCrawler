using System;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Fight
{
    private Inhabitant attacker;
    private Inhabitant defender;
    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI monsterHealthText;
    public bool fightIsOver = false;


    public Fight(TextMeshProUGUI playerHealthText, TextMeshProUGUI monsterHealthText)
    {
        this.playerHealthText = playerHealthText;
        this.monsterHealthText = monsterHealthText;
    }

    public void SetUpFight()
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
        Debug.Log($"The first attacker is {attacker.getName()}, they have {attacker.getCurrHP()} health and they have the Armor Class: {attacker.getAC()}");
        Debug.Log($"The first defender is {defender.getName()}, they have {defender.getCurrHP()} health and they have the Armor Class: {defender.getAC()}");
        
    }

    public void doAttack(GameObject playerGameObject, GameObject monsterGameObject)
    {
        
        if (fightIsOver) return;


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
                if (this.defender is Player)
                {
                    Debug.Log("Player died");
                    playerGameObject.SetActive(false);
                }
                else
                {
                    Debug.Log("Monster died");
                    GameObject.Destroy(monsterGameObject);
                }
                fightIsOver = true;
                
                return;
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

    public void HealthBar()
    {

        playerHealthText.text = $"Player Health Bar: {Core.thePlayer.getCurrHP()}";
        monsterHealthText.text = $"Monster Health Bar: {Core.theMonster.getCurrHP()}";
        
    }

}