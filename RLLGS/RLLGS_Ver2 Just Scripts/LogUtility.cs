using UnityEngine;

namespace SametHope.RLLGS
{
    /// <summary>
    /// Logging but with some formatting and more information.
    /// </summary>
    public static class LogUtility
    {
        public static void Log(this object obj, string logMessage)
        {
            Debug.Log($"[{obj.GetType()}] {logMessage}");
        }
        public static void LogWarning(this object obj, string logMessage)
        {
            Debug.LogWarning($"[{obj.GetType().Name}] {logMessage}");
        }
        public static void LogError(this object obj, string logMessage)
        {
            Debug.LogError($"[{obj.GetType().Name}] {logMessage}");
        }
    }
}
