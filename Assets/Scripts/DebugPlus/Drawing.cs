using UnityEngine;
using System.Collections;
using System;

namespace DebugPlusAsset {
    public class Drawing {
        public Action action;
        public Color color;
        public Matrix4x4 matrix;
        public float duration;

        public Drawing(Action action, Color color, float duration, Matrix4x4 matrix) {
            this.action = action;
            this.color = color;
            this.duration = duration;
            this.matrix = matrix;
        }
    }
}