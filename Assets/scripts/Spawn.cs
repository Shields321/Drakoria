using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Spawn : MonoBehaviour
    {
        public GameObject Entity;
        public Transform player;
        public float spawnRate;
        private float timer = 0f;
        private float spawnRadius = 5f;
        void Start()
        {
            player = transform;
            spawnEntity();
        }
        void Update()
        {
            timer += Time.deltaTime;
            if (timer >= spawnRate)
            {
                spawnEntity();
                timer = 0f;
            }
        }
        public void spawnEntity()
        {            

            Debug.Log("spawning Entity");
            Vector2 offset = Random.insideUnitSphere * spawnRadius;
            Vector2 spawnPos = (Vector2)player.position + offset;
            
            Instantiate(Entity, spawnPos, Quaternion.identity);
        }

    }
}
