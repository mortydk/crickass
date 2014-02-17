using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Stats))]
public class HitDamage : MonoBehaviour, IHitable {

    public Action hasDied;
    public Action hasTakenDamage;
    public float AttackDamage;

    Stats stats;
    IKillable killable;

    bool isDead = false;
    
    void Start()
    {
        stats = GetComponent<Stats>();
        killable = (IKillable)GetComponent(typeof(IKillable));
        if (killable == null)
            throw new MissingComponentException("Requires an implementation of IKillable");
    }

    public void Hit()
    {
        stats.Health -= AttackDamage;

        if (hasTakenDamage != null)
            hasTakenDamage();

        if (stats.Health <= 0 && !isDead)
        {
            killable.Kill();

			if (hasDied != null)
				hasDied();

            isDead = true;
        }
    }
}
