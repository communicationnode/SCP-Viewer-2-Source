using Jint;
using System;
using UnityEngine;
using UnityEngine.UI;

public class JintConsole : MonoBehaviour {
    /*
     * values
     */
    [SerializeField] private Text consoleLogTemplate;
    [SerializeField] private InputField consoleInputField;
    Engine engine;

    /*
     * methods
     */
    private void Start() {
        InitializeLog();
        /*
        * define js interpreter ECMAscripts 5.1
        */
        engine = new Engine(cfg => cfg.AllowClr(
    typeof(UnityEngine.Random).Assembly,
    typeof(Debug).Assembly,
    typeof(Mathf).Assembly));

        engine.Execute(@"var UnityEngine = importNamespace('UnityEngine');");
        engine.SetValue("setResolution", (Action<int, int>)((width, height) => { Screen.SetResolution(width, height, true); }));
        engine.SetValue("echo", (Action<object>)((logObject) => { Log(logObject.ToString()); }));
        engine.SetValue("clearMemory", (Action)(() => { engine = new Engine(); Log("Clear <color=green>completed</color>"); }));
        engine.SetValue("timeScale", (Action<float>)((value) => { Time.timeScale = value; }));
    }

    /*
     * clear input field + if exception -> log it
     */
    private void InitializeLog() {
        consoleInputField.onSubmit.AddListener((message) => {
            consoleInputField.SetTextWithoutNotify("");
            try {
                engine.Execute(message);
            } catch (Exception e) {
                Log(e.ToString(), @"#FF1111FF");
            }
        });
    }
    private void Log(in string log, string color = @"#FFFFFFFF") {
        Text newLog = GameObject.Instantiate(consoleLogTemplate, consoleLogTemplate.transform.parent.transform);
        newLog.text = log;
        ColorUtility.TryParseHtmlString(color, out Color result);
        newLog.color = result;
    }
}
