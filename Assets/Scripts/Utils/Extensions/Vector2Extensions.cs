using UnityEngine;

namespace Utils.Extensions {
    internal static class Vector2Extensions {
        internal static Vector2Int ToVector2Int(this Vector2 value) {
            return new Vector2Int(Mathf.RoundToInt(value.x), Mathf.RoundToInt(value.y));
        }
    }
}