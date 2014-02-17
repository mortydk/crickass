using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {
	
    public Transform player;
    public AnimationClip attackAnimation;
    public AudioClip attackAudio;
    public float attackRange = 2;
    public float attackDelay = 2;

    bool isCharging = false;

    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    private bool IsInAttackRange
    {
        get { return Vector3.Distance(transform.position, player.position) < attackRange; }
    }

	void Update ()
    {
	    //check distance between enemy and player
        if (IsInAttackRange && !isCharging)
        {
            Invoke("Attack", attackDelay);
            isCharging = true;
        }
	}
    
    private void Attack()
    {
        isCharging = false;

        if (!IsInAttackRange)
            return;

        ActivateHitables.HitAll(player.gameObject);

        // animation.CrossFade(attackAnimation.name); // So far, this animation makes the run animation disappear afterwards

        audio.PlayOneShot(attackAudio);
    }
}
