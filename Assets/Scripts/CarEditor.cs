using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CarCreator))]
public class CarEditor : Editor
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();
		
		CarCreator script = (CarCreator)target;

		if(GUILayout.Button("Create a Random Car"))
		{
				script.NewCar();
		}

		if(GUILayout.Button("Save as Prefab"))
		{
				script.SaveCar();
		}
	}
}
