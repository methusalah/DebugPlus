using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

namespace DebugPlusNS {
    public class LogDrawer : SingletonBehavior<LogDrawer> {
        private const int LOG_CAPACITY = 30;

        public readonly List<LogEntry> logEntries = new List<LogEntry>();
        private List<Text> texts;

        private void Start() {
            GameObject cgo = new GameObject("DebugPlusCanvas");
            DontDestroyOnLoad(cgo);

            // canvas
            var canvas = cgo.AddComponent<Canvas>();
            canvas.sortingOrder = 0;
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;

            // vertical layout
            var vlgo = new GameObject("Log", typeof(VerticalLayoutGroup));
            vlgo.transform.parent = cgo.transform;

            var vlg = vlgo.GetComponent<VerticalLayoutGroup>();
            vlg.childForceExpandHeight = false;
            vlg.childForceExpandWidth = false;
            vlg.childControlHeight = false;

            var vlRect = vlgo.GetComponent<RectTransform>();
            vlRect.anchorMin = new Vector2(0.05f, 0.3f);
            vlRect.anchorMax = new Vector2(0.7f, 0.95f);
            vlRect.anchoredPosition = Vector2.zero;
            vlRect.sizeDelta = Vector2.zero;

            // texts
            I.texts = new List<Text>();
            for (int i = 0; i < LOG_CAPACITY; i++) {
                var go = new GameObject("Log entry", typeof(Text));
                go.transform.parent = vlgo.transform;
                go.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 17);
                //go.GetComponent<RectTransform>().ForceUpdateRectTransforms();
                var t = go.GetComponent<Text>();
                t.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
                I.texts.Add(t);
            }
        }

        private void Update() {
            if (texts != null) {
                for (int i = 0; i < LOG_CAPACITY; i++) {
                    var t = texts[i];
                    if (i < logEntries.Count) {
                        t.gameObject.SetActive(true);
                        t.text = logEntries[i].text;
                        t.color = logEntries[i].color;
                    } else {
                        t.gameObject.SetActive(false);
                    }
                }
            }

            foreach (var le in logEntries.ToList()) {
                le.duration -= Time.deltaTime;
                if (le.duration <= 0) {
                    logEntries.Remove(le);
                }
            }
        }

        public static void Log(LogEntry logEntry) {
            I.logEntries.Insert(0, logEntry);
        }

        [RuntimeInitializeOnLoadMethod]
        static void Init() {
            applicationIsQuitting = false;
        }
    }
}
