using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    public Transform AttackPoint;
    public LayerMask hitMask;

    void Attack()
    {
        var hits = Physics.OverlapSphere(AttackPoint.position, 0.5f, hitMask);

        foreach (var hit in hits)
        {
            ActivateHitables.HitAll(hit.gameObject);
        }
    }
}
