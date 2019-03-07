using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

namespace DebugPlusAsset {
    public class GizmoDrawer : SingletonBehavior<GizmoDrawer> {
        public readonly List<Drawing> drawings = new List<Drawing>();

        private void Update() {
            foreach (var d in drawings) {
                d.duration -= Time.deltaTime;
            }
        }

        private void OnDrawGizmos() {
            foreach (var d in drawings.ToList()) {
                var prevColor = Gizmos.color;
                var prevMatrix = Gizmos.matrix;
                Gizmos.color = d.color;
                if (d.matrix != default) {
                    Gizmos.matrix = d.matrix;
                }
                d.action();

                Gizmos.color = prevColor;
                Gizmos.matrix = prevMatrix;

                // we remove the drawing here and not in the update to ensure that
                // drawings with 0 duration will be drawn at least one time.
                if (d.duration <= 0) drawings.Remove(d);
            }
        }

        public static void Draw(Drawing drawing) {
            I.drawings.Add(drawing);
        }
    }
}
