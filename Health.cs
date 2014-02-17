using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
    float health = 100.0f;

    void Start()
    {

    }

    void Update()
    {
        guiText.text = "HP: " + health.ToString();
    }

}
