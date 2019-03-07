using UnityEngine;
using System.Collections;

namespace DebugPlusAsset {
    public class LogEntry {
        public string text;
        public Color color;
        public float duration;

        public LogEntry(string text, Color color, float duration) {
            this.text = text;
            this.color = color;
            this.duration = duration;
        }
    }
}