using UnityEngine;

namespace Vectors
{
    public static class DrawingHelper
    {
        public static void DrawPoint(Vector2 position, Color color)
        {
            int d = 6;
            for (int i = 0; i < d; i++)
            {
                Vector2 from = new Vector2((Mathf.Cos((180 / d * i * Mathf.PI) / 180)) / 2, (Mathf.Sin((180 / d * i * Mathf.PI) / 180)) / 2);
                Vector2 to = -from;
                Debug.DrawLine(position + from, position + to, color);
            }
        }
    }
}