using System.Linq;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(EnumArrayAttribute))]
public class EnumArray : PropertyDrawer
{
	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		string[] names = ((EnumArrayAttribute)attribute).names;
		int index = int.Parse(property.propertyPath.Split('[', ']').Where(c => !string.IsNullOrEmpty(c)).Last());

		if (index < names.Length)
		{
			label.text = names[index];
		}
		EditorGUI.PropertyField(position, property, label, includeChildren: true);
	}

	public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
	{
		return EditorGUI.GetPropertyHeight(property, label, includeChildren: true);
	}

}
