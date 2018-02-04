using UnityEditor;
using UnityEngine;
using Vectors.CustomProperty.Attribute;

namespace Vectors.CustomProperty.Drawer
{
    [CustomPropertyDrawer(typeof(_CA_ReadOnlyLabelAttribute))]
    public class _CD_ReadOnlyLabelDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property,
            GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var propertyAttribute = this.attribute as _CA_ReadOnlyLabelAttribute;
            label.text = propertyAttribute.Label;
            
            GUI.enabled = false;
            EditorGUI.PropertyField(position, property, label, true);
            GUI.enabled = true;
        }
    }
}