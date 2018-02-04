using UnityEditor;
using UnityEngine;
using Vectors.CustomProperty.Attribute;

// // https://answers.unity.com/questions/489942/how-to-make-a-readonly-property-in-inspector.html
namespace Vectors.CustomProperty.Drawer
{
    [CustomPropertyDrawer(typeof(_CA_ReadOnlyAttribute))]
    public class _CD_ReadOnlyDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property,
            GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            GUI.enabled = false;
            EditorGUI.PropertyField(position, property, label, true);
            GUI.enabled = true;
        }
    }
}