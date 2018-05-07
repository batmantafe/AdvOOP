using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SunnyLand
{
    [RequireComponent(typeof(BoxCollider2D))]

    public class Climbable : MonoBehaviour
    {
        public Vector2 offset;
        public Vector2 zoneCenter;
        public Vector2 zoneSize;

        [Header("Debug")]
        public Color zoneColor = new Color(1, 0, 0, .5f);
        public Color lineColor = Color.white;

        private Bounds zone;
        private Bounds box;
        private BoxCollider2D col;
        public Vector2 size, top, bottom;

        // Use this for initialization
        void Start()
        {
            RecalculateBounds();
        }

        void OnDrawGizmos()
        {
            // If we are in the Application Editor
            if (Application.isEditor)
            {
                // Draw the debug lines
                RecalculateBounds();

                Gizmos.color = zoneColor;
                Gizmos.DrawCube(zone.center, zone.size);

                Gizmos.color = lineColor;
                Gizmos.DrawLine(top, bottom);
            }
        }

        void RecalculateBounds()
        {
            col = GetComponent<BoxCollider2D>();
            box = col.bounds;
            size = box.size;

            // Create a new Bounds based on boxCollider
            zone = new Bounds(box.center + (Vector3)zoneCenter,
                                box.size + (Vector3)zoneSize);

            // Get position of transform
            Vector2 position = transform.position;

            // Calculate top and bottom
            top = position + new Vector2(offset.x, 0);
            bottom = position + new Vector2(offset.x, -size.y + offset.y);
        }

        public float GetX()
        {
            return zone.center.x;
        }

        public bool IsAtTop(Vector3 point)
        {
            // Return true if player is at top
            return point.y > zone.max.y;
        }

        public bool IsAtBottom(Vector3 point)
        {
            // Return true if the player is at bottom
            return point.y < zone.min.y;
        }
    }
}
