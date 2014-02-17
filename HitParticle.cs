using UnityEngine;
using System.Collections;

public class HitParticle : MonoBehaviour, IHitable {

    public ParticleSystem particle;

	public void Hit ()
    {
        particle.Play();
	}
}
