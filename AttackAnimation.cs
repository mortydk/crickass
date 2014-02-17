using UnityEngine;
using System.Collections;

public class AttackAnimation : MonoBehaviour {

    public AnimationClip AttackAnimationClip;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0))
        {
            animation.Play(AttackAnimationClip.name);
        }
        else if (IsAttackFinished)
        {
            animation.CrossFade(animation.clip.name);
        }
	}

    private bool IsAttackFinished
    {
        get { return animation[AttackAnimationClip.name].time > animation[AttackAnimationClip.name].length; }
    }
}
