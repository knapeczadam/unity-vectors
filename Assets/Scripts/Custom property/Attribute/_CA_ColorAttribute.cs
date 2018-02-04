using UnityEditor;
using UnityEngine;

// // https://forum.unity.com/threads/drawing-a-field-using-multiple-property-drawers.479377/
namespace Vectors.CustomProperty.Attribute
{
    public class _CA_ColorAttribute : _CA_MultiPropertyAttribute
    {
        Color Color;

        public _CA_ColorAttribute(float r, float g, float b)
        {
            Color = new Color(r, g, b);
        }

        public _CA_ColorAttribute(float r, float g, float b, float a)
        {
            Color = new Color(r, g, b, a);
        }

        // Draw the property inside the given rect
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            GUI.color = Color;
        }
    }
}