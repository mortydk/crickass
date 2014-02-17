using UnityEngine;
using System.Collections;

public class NGUIHealth : MonoBehaviour
{
    UILabel label;

	// Use this for initialization
	void Start ()
    {
        label = GetComponent<UILabel>();

        label.text = "Hello world";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
