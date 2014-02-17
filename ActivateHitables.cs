using UnityEngine;
using System.Collections;

public class ActivateHitables {

	public static void HitAll(GameObject gameObject)
    {
            var hitables = gameObject.GetComponents(typeof(IHitable));

            if (hitables == null)
                return;

            foreach (IHitable hitable in hitables)
                hitable.Hit();
    }
}
