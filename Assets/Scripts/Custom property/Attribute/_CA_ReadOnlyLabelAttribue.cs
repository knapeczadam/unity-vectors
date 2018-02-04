using UnityEngine;

namespace Vectors.CustomProperty.Attribute
{
    public class _CA_ReadOnlyLabelAttribute : PropertyAttribute
    {
        public string Label { get; private set; }
    
        public _CA_ReadOnlyLabelAttribute(string label)
        {
            this.Label = label;
        }
    }
}
