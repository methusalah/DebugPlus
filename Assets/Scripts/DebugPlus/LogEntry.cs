using UnityEngine;
using System.Collections;

namespace DebugPlusAsset {
    public class LogEntry {
        internal string text;
        internal Color color;
        internal float duration;

        internal LogEntry(string text) {
            this.text = text;
        }

        public LogEntry Color(Color color) {
            this.color = color;
            return this;
        }

        public LogEntry Duration(float duration) {
            this.duration = duration;
            return this;
        }
    }
}