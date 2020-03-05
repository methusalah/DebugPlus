using UnityEngine;
using System.Collections;
using System;

namespace DebugPlusNS {
    public class Drawing {
        internal Action action;
        internal Color color = UnityEngine.Color.red;
        internal Matrix4x4 matrix = Matrix4x4.identity;
        internal float duration = 0;
        internal int creationFrame;

        internal Drawing (Action action) {
            this.action = action;
            creationFrame = Time.frameCount;
        }

        public Drawing Color(Color color) {
            this.color = color;
            return this;
        }

        public Drawing Duration(float duration) {
            this.duration = duration;
            return this;
        }

        public Drawing Matrix(Matrix4x4 matrix) {
            this.matrix = matrix;
            return this;
        }
    }
}