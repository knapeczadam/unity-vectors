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

        public static void DrawRectangle(Vector2 center, float width, float height, Color color)
        {
            Vector2 topLeft = center + new Vector2(-width / 2, height / 2);
            Vector2 topRight = topLeft + new Vector2(width, 0);
            Vector2 bottomLeft = topLeft + new Vector2(0, -height);
            Vector2 bottomRight = topRight + new Vector2(0, -height);
            
            Debug.DrawLine(topLeft, topRight, color);
            Debug.DrawLine(bottomLeft, bottomRight, color);
            Debug.DrawLine(topLeft, bottomLeft, color);
            Debug.DrawLine(topRight, bottomRight, color);
        }
    }
}