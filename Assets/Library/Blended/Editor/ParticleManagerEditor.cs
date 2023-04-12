#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Blended.Editor
{
    [CustomEditor(typeof(ParticleManager))]
    [CanEditMultipleObjects]
    public class ParticleManagerEditor : UnityEditor.Editor
    {
        private ParticleManager _particleManager;

        private void OnEnable()
        {
            _particleManager = target as ParticleManager;
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            GUILayout.Space(10);

            GUI.color = Color.green;
            if (GUILayout.Button("Add Particles"))
            {
                _particleManager.LoadParticleList();
                UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
            }

            GUI.color = Color.red;
            if (GUILayout.Button("Clear Particles"))
            {
                _particleManager.ClearParticleList();
                UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(SceneManager.GetActiveScene());
            }
        }
    }
}
#endif