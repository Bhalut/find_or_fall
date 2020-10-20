//#define PERFTEST
////For testing performance of parse/stringify.  Turn on editor profiling to see how we're doing

using UnityEngine;
using UnityEditor;

public class JSONChecker : EditorWindow 
{
	private string _json = @"{
	""TestObject"": {
		""SomeText"": ""Blah"",
		""SomeObject"": {
			""SomeNumber"": 42,
			""SomeBool"": true,
			""SomeNull"": null
		},
		
		""SomeEmptyObject"": { },
		""SomeEmptyArray"": [ ],
		""EmbeddedObject"": ""{\""field\"":\""Value with \\\""escaped quotes\\\""\""}""
	}
}";	  //dat string literal...

	private JSONObject _j;
	[MenuItem("Window/JSONChecker")]
	private static void Init() 
	{
		GetWindow(typeof(JSONChecker));
	}

	private void OnGUI() 
	{
		_json = EditorGUILayout.TextArea(_json);
		GUI.enabled = !string.IsNullOrEmpty(_json);
		if(GUILayout.Button("Check JSON")) 
		{
#if PERFTEST
            Profiler.BeginSample("JSONParse");
			j = JSONObject.Create(JSON);
            Profiler.EndSample();
            Profiler.BeginSample("JSONStringify");
            j.ToString(true);
            Profiler.EndSample();
#else
			_j = JSONObject.Create(_json);
#endif
			Debug.Log(_j.ToString(true));
		}
		if (_j) 
		{
			//Debug.Log(System.GC.GetTotalMemory(false) + "");
			if (_j.type == JSONObject.Type.NULL)
				GUILayout.Label("JSON fail:\n" + _j.ToString(true));
			else
				GUILayout.Label("JSON success:\n" + _j.ToString(true));
		}
	}
}
