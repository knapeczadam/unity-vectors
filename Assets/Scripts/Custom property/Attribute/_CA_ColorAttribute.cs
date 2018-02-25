using UnityEditor;
using UnityEngine;

// // https://forum.unity.com/threads/drawing-a-field-using-multiple-property-drawers.479377/
namespace Vectors.CustomProperty.Attribute
{
    public enum _Color
    {
        Black = 0,
        Blue = 1,
        Clear = 2,
        Cyan = 3,
        Gray = 4,
        Green = 5,
        Grey = 6,
        Magenta = 7,
        Red = 8,
        White = 9,
        Yellow = 10
    }

    public class _CA_ColorAttribute : _CA_MultiPropertyAttribute
    {
        private static readonly Color[] Colors;

        static _CA_ColorAttribute()
        {
            Colors = new Color[11];
            Colors[(int) _Color.Black] = Color.black;
            Colors[(int) _Color.Blue] = Color.blue;
            Colors[(int) _Color.Clear] = Color.clear;
            Colors[(int) _Color.Cyan] = Color.cyan;
            Colors[(int) _Color.Gray] = Color.gray;
            Colors[(int) _Color.Green] = Color.green;
            Colors[(int) _Color.Grey] = Color.grey;
            Colors[(int) _Color.Magenta] = Color.magenta;
            Colors[(int) _Color.Red] = Color.red;
            Colors[(int) _Color.White] = Color.white;
            Colors[(int) _Color.Yellow] = Color.yellow;
        }

        private readonly Color _color;

        public _CA_ColorAttribute(_Color color)
        {
            _color = Colors[(int) color];
        }

        public _CA_ColorAttribute(float r, float g, float b)
        {
            _color = new Color(r, g, b);
        }

        public _CA_ColorAttribute(float r, float g, float b, float a)
        {
            _color = new Color(r, g, b, a);
        }

        // Draw the property inside the given rect
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            GUI.color = _color;
        }
    }
}