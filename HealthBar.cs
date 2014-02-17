using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour
{

    public Stats playerStats;
    UISlider healthBar;

    void Start()
    {
        playerStats = GameObject.Find("Player").GetComponent<Stats>();
        if (playerStats = null)
            throw new MissingReferenceException("Cannot find player stats or player");

        playerStats.GetComponent<HitDamage>().hasTakenDamage += PlayerHasTakenDamage;

        healthBar = GetComponent<UISlider>();
        if(healthBar == null)
            throw new MissingReferenceException("HealthBar requires UISlider");
    }

    void PlayerHasTakenDamage()
    {
        healthBar.value = playerStats.Health / 500;
    }
}
