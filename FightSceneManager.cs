using System;
using System.Threading;
using TMPro;
using UnityEngine;

public class fightSceneManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject player;
    public GameObject monster;
    private Fight theFight;
    private float timer = 0f;

    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI monsterHealthText;
    void Start()
    {
        theFight = new Fight(playerHealthText, monsterHealthText);
        theFight.SetUpFight();
        theFight.HealthBar();
    }

    // Update is called once per frame
    void Update()
    {


        if (theFight.fightIsOver) return;

        timer += Time.deltaTime;
        if (timer >= 2f)
        {
            theFight.doAttack(player, monster, false);
            timer = 0f;
        }
        

        if (Input.GetKeyDown(KeyCode.H))
        {
            theFight.Heal();
            
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            theFight.doAttack(player,monster,true);

        }

        theFight.HealthBar();

    }
}