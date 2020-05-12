// This script is modified from the original 
namespace ArionDigital
{
    using UnityEngine;

    public class CrashCrate : Breakable
    {
        public GameObject spawnObject;
        public Vector3 spawnOffset = new Vector3(0, 0, 0);

        [Header("Whole Create")]
        public MeshRenderer wholeCrate;
        public BoxCollider boxCollider;
        [Header("Fractured Create")]
        public GameObject fracturedCrate;
        [Header("Audio")]
        public AudioSource crashAudioClip;

        override public void Break()
        {
            wholeCrate.enabled = false;
            boxCollider.enabled = false;
            fracturedCrate.SetActive(true);
            crashAudioClip.Play();

            if (spawnObject != null)
            {
                Instantiate(spawnObject, gameObject.transform.position + spawnOffset, Quaternion.identity);
            }
        }

        [ContextMenu("Test")]
        public void Test()
        {
            wholeCrate.enabled = false;
            boxCollider.enabled = false;
            fracturedCrate.SetActive(true);
        }
    }
}