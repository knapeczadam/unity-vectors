using UnityEditor;
using UnityEngine;

// // https://forum.unity.com/threads/drawing-a-field-using-multiple-property-drawers.479377/
namespace Vectors.CustomProperty.Attribute
{
    public class _CA_RangeAttribute : _CA_MultiPropertyAttribute
    {
        private readonly string _newLabel;
        private readonly float _min;
        private readonly float _max;

        public _CA_RangeAttribute(float min, float max)
        {
            this._min = min;
            this._max = max;
        }

        public _CA_RangeAttribute(string newLabel, float min, float max)
        {
            this._newLabel = newLabel;
            this._min = min;
            this._max = max;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (_newLabel != null)
            {
                label.text = _newLabel;
            }
            if (property.propertyType == SerializedPropertyType.Float)
            {
                EditorGUI.Slider(position, property, _min, _max, label);
            }
            else if (property.propertyType == SerializedPropertyType.Integer)
            {
                EditorGUI.IntSlider(position, property, (int) _min, (int) _max, label);
            }
            else
            {
                EditorGUI.LabelField(position, label.text, "Use Range with float or int.");
            }
        }
    }
}