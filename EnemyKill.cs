using UnityEngine;
using System.Collections;

public class EnemyKill : MonoBehaviour, IKillable {

    public AudioClip deathSound;
    public AnimationClip deathAnimation;
    public int CorpeStayTime = 10;

    AIFollow aiFollow;

    void Start()
    {
        aiFollow = GetComponent<AIFollow>();

        if (aiFollow == null)
            throw new MissingComponentException("Missing AIFollow Component");
    }

    public void Kill()
    {
        //walk through enemy when they're dead, but still visible
        gameObject.collider.enabled = false;

        //Set the enemies y position to 0, when it dies - AKA if it dies in the air, it will fall to the ground
        Vector3 newPos = new Vector3(gameObject.transform.position.x, 0, gameObject.transform.position.z);
        gameObject.transform.position = newPos;

        Destroy(gameObject, CorpeStayTime);
        audio.PlayOneShot(deathSound);
        animation.CrossFade(deathAnimation.name);
        aiFollow.canMove = false;
    }
}
