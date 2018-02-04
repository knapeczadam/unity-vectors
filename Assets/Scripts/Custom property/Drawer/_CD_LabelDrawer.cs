using UnityEditor;
using UnityEngine;
using Vectors.CustomProperty.Attribute;

// // https://answers.unity.com/questions/1005277/can-i-change-variable-name-on-inspector.html
namespace Vectors.CustomProperty.Drawer
{
    [CustomPropertyDrawer(typeof(_CA_LabelAttribute))]
    public class _CD_LabelDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var propertyAttribute = this.attribute as _CA_LabelAttribute;
            label.text = propertyAttribute.Label;
            EditorGUI.PropertyField(position, property, label);
        }
    }
}
