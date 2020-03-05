using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace DebugPlusNS {
    public class Demo : MonoBehaviour {
        private float yaw, pitch;

        public GameObject go;

        void Update() {
            pitch -= Input.GetAxis("Mouse Y");
            pitch = Mathf.Clamp(pitch, -90, 90);
            yaw += Input.GetAxis("Mouse X");

            Camera.main.transform.rotation = Quaternion.Euler(pitch, yaw, 0);

            bool space = Input.GetKey(KeyCode.Space);

            // some logs on screen
            DebugPlus.LogOnScreen(space ? "space key down !" : "space key up")
                .Color(space ? Color.green : Color.red)
                .Duration(1);
            DebugPlus.LogOnScreen("yaw: " + yaw + " pitch: " + pitch)
                .Color(pitch > 0 ? Color.blue : Color.green);

            // some gizmos
            if (space) {
                DebugPlus.DrawWireSphere(new Vector3(0, 1, -2), 0.8f)
                    .Color(Color.red)
                    .Duration(2);
                DebugPlus.DrawSphere(new Vector3(0, 1, 0), 1)
                    .Color(Color.blue)
                    .Duration(2);
                DebugPlus.DrawCube(Vector3.zero, new Vector3(1, 2, 1))
                    .Color(Color.cyan)
                    .Matrix(go.transform.localToWorldMatrix);
            }
        }

        private void Awake() {
            // some code timing
            MethodA();
            MethodA();
            MethodA();
            MethodA();
            MethodA();
            Debug.Log(DebugPlus.GetChronometerReport());
        }

        private void MethodA() {
            DebugPlus.StartChronometer();

            MethodB();
            MethodC();

            DebugPlus.StopCurrentChronometer();
        }
        private void MethodB() {
            DebugPlus.StartChronometer();

            DebugPlus.StartChronometer("sub bloc");
            // your timed sub bloc
            Thread.Sleep(3);
            DebugPlus.StopCurrentChronometer();
            
            MethodC();
            MethodC();
            MethodC();
            
            DebugPlus.StopCurrentChronometer();
        }
        private void MethodC() {
            DebugPlus.StartChronometer(showAverage:true);

            Thread.Sleep(10);

            DebugPlus.StopCurrentChronometer();
        }
    }
}
