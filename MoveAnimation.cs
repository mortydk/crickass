using UnityEngine;
using System.Collections;

public class MoveAnimation : MonoBehaviour {

    public float BaseAnimationSpeed = 0.2f;
    public float AnimationSpeedModifier = 0.25f;
    public CharacterMotor motor;

    Animation animation;

	// Use this for initialization
	void Start () {
        animation = GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void Update () {
        animation[animation.clip.name].speed = motor.movement.velocity.magnitude * AnimationSpeedModifier + BaseAnimationSpeed;	
	}
}
