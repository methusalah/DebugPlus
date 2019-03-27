using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScript : MonoBehaviour
{
    private float yaw, pitch;

    public GameObject go;

    void Update()
    {
        pitch -= Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, -90, 90);
        yaw += Input.GetAxis("Mouse X");

        Camera.main.transform.rotation = Quaternion.Euler(pitch, yaw, 0);

        bool space = Input.GetKey(KeyCode.Space);

        // some logs on screen
        DebugPlus.LogOnScreen(space? "space key down !" : "space key up")
            .Color(space? Color.green : Color.red)
            .Duration(1);
        DebugPlus.LogOnScreen("yaw: " + yaw + " pitch: " + pitch)
            .Color(pitch > 0 ? Color.blue : Color.green);

        // some gizmos

        if (Input.GetKeyDown(KeyCode.Space)) {
            DebugPlus.DrawWireSphere(new Vector3(0, 1, -2), 0.8f)
                .Color(Color.red)
                .Duration(2);
            DebugPlus.DrawSphere(new Vector3(0, 1, 0), 1)
                .Color(Color.blue)
                .Duration(2);
        }

        if (space) {
            DebugPlus.DrawCube(Vector3.zero, new Vector3(1, 2, 1))
                .Color(Color.cyan)
                .Matrix(go.transform.localToWorldMatrix);
        }
    }
}
