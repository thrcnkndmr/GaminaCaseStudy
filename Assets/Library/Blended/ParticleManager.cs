using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace Blended
{
    public class ParticleManager : MonoSingleton<ParticleManager>
    {
        public List<ParticleSystem> particleList;
        private List<ParticleSystem> currentParticleList;


        #region Particle Manager

        public void ParticlePlayOnTransform(int index, Transform particleTransform)
        {
            currentParticleList[index].gameObject.transform.position = particleTransform.position;
            particleList[index].Play();
        }

        public void ParticlePlayOnVector(int index, Vector3 particleTransform)
        {
            currentParticleList[index].gameObject.transform.position = particleTransform;
            currentParticleList[index].Play();
        }

        public IEnumerator ParticlePlayTimeOnTransform(int index, Transform particleTransform, float time)
        {
            yield return time.GetWait();
            currentParticleList[index].gameObject.transform.position = particleTransform.position;
            currentParticleList[index].Play();
        }

        #endregion

        #region Functions

        public void LoadParticleList()
        {
            ClearParticleList();

#if UNITY_EDITOR
            for (int i = 0; i < particleList.Count; i++)
            {
                ParticleSystem particle = (ParticleSystem)PrefabUtility.InstantiatePrefab(particleList[i], transform);
                currentParticleList.Add(particle);
            }
#endif
        }

        public void ClearParticleList()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                DestroyImmediate(transform.GetChild(i).gameObject);
                currentParticleList.Remove(currentParticleList[i]);
                --i;
            }
        }

        #endregion
    }
}