using UnityEngine;
using System.Collections;

public class StartActions : MonoBehaviour {

    public static bool lockCursor = true; // Set this to enable/disable the lock (show/hide mousecursor).
    void Update()
    {
        if (Screen.lockCursor != lockCursor)
        {
            if (lockCursor && Input.GetMouseButton(0))
                Screen.lockCursor = true;
            else if (!lockCursor)
                Screen.lockCursor = false;
        }
    }

}
