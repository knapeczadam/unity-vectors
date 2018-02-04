using System.Linq;
using UnityEditor;
using UnityEngine;
using Vectors.CustomProperty.Attribute;

// // https://forum.unity.com/threads/drawing-a-field-using-multiple-property-drawers.479377/
namespace Vectors.CustomProperty.Drawer
{
#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(_CA_MultiPropertyAttribute), true)]
    public class _CD_MultiPropertyDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            _CA_MultiPropertyAttribute @Attribute = attribute as _CA_MultiPropertyAttribute;
            float height = base.GetPropertyHeight(property, label);
            foreach (object atr in @Attribute.Stored
            ) //Go through the attributes, and try to get an altered height, if no altered height return default height.
            {
                if (atr as _CA_MultiPropertyAttribute != null)
                {
                    //build label here too?
                    var tempheight = ((_CA_MultiPropertyAttribute) atr).GetPropertyHeight(property, label);
                    if (tempheight.HasValue)
                    {
                        height = tempheight.Value;
                        break;
                    }
                }
            }
            return height;
        }

        // Draw the property inside the given rect
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            _CA_MultiPropertyAttribute @Attribute = attribute as _CA_MultiPropertyAttribute;
            // First get the attribute since it contains the range for the slider
            if (@Attribute.Stored == null || @Attribute.Stored.Count == 0)
            {
                @Attribute.Stored = fieldInfo.GetCustomAttributes(typeof(_CA_MultiPropertyAttribute), false)
                    .OrderBy(s => ((PropertyAttribute) s).order).ToList();
            }
            var OrigColor = GUI.color;
            var Label = label;
            foreach (object atr in @Attribute.Stored)
            {
                if (atr as _CA_MultiPropertyAttribute != null)
                {
                    Label = ((_CA_MultiPropertyAttribute) atr).BuildLabel(Label);
                    ((_CA_MultiPropertyAttribute) atr).OnGUI(position, property, Label);
                }
            }
            GUI.color = OrigColor;
        }
    }
#endif
}