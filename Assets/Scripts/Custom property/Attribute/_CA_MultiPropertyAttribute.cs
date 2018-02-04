using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// // https://forum.unity.com/threads/drawing-a-field-using-multiple-property-drawers.479377/
namespace Vectors.CustomProperty.Attribute
{
    [AttributeUsage(AttributeTargets.Field)]
    public abstract class _CA_MultiPropertyAttribute : PropertyAttribute
    {
        private List<object> _stored = new List<object>();

        public List<object> Stored
        {
            get { return _stored; }
            set { _stored = value; }
        }

        public virtual GUIContent BuildLabel(GUIContent label)
        {
            return label;
        }

        public abstract void OnGUI(Rect position, SerializedProperty property, GUIContent label);

        internal virtual float? GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return null;
        }
    }
}