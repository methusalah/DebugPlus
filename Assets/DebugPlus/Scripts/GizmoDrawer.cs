using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

namespace DebugPlusNS {
    public class GizmoDrawer : SingletonBehavior<GizmoDrawer> {
        public readonly List<Drawing> drawings = new List<Drawing>();

        private void Update() {
            foreach (var d in drawings.ToList()) {
                if (d.creationFrame == Time.frameCount) continue;
                d.duration -= Time.deltaTime;
                if (d.duration < 0) drawings.Remove(d);
            }
        }

        private void OnDrawGizmos() {
            foreach (var d in drawings) {
                var prevColor = Gizmos.color;
                var prevMatrix = Gizmos.matrix;
                Gizmos.color = d.color;
                if (d.matrix != default(Matrix4x4))  {
                    Gizmos.matrix = d.matrix;
                }
                d.action();

                Gizmos.color = prevColor;
                Gizmos.matrix = prevMatrix;
            }
        }

        public static void Draw(Drawing drawing) {
            I.drawings.Add(drawing);
        }

        [RuntimeInitializeOnLoadMethod]
        static void Init() {
            applicationIsQuitting = false;
        }
    }
}
