using UnityEngine;

// // https://answers.unity.com/questions/1005277/can-i-change-variable-name-on-inspector.html
namespace Vectors.CustomProperty.Attribute
{
    public class _CA_LabelAttribute : PropertyAttribute
    {
        public string Label { get; private set; }

        public _CA_LabelAttribute(string label)
        {
            this.Label = label;
        }
    }
}