using UnityEngine;
using System.Collections;

namespace DebugPlusNS {
    public class LogEntry {
        internal string text;
        internal Color color = UnityEngine.Color.red;
        internal float duration = 0;

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