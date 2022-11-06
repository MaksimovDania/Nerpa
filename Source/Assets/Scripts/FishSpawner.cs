using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core {
    public class FishSpawner : MonoBehaviour 
    {
        [SerializeField] private GameObject omul;
        [SerializeField] private GameObject oilfish;
        [SerializeField] private GameObject bullfish;

        [SerializeField] private int omulPopulation;
        [SerializeField] private int oilfishPopulation;
        [SerializeField] private int bullfishPopulation;

        [SerializeField] private float spawnPeriod;
        [SerializeField] private float distance;

        [SerializeField] private List<Transform> areas;

        [SerializeField] public List<GameObject> omuls;
        [SerializeField] public List<GameObject> oilfishs;
        [SerializeField] public List<GameObject> bullfishs;
        private float timer;
        public static FishSpawner instance;

        private void Start() 
        {
            if (instance == null)
                instance = this;
            else
                Destroy(gameObject);

            timer = 0f;
        }

        private void FixedUpdate() 
        {
            if (timer > spawnPeriod) 
            {
                timer = 0f;
                SpawnTillRequired();
            }
            timer += Time.deltaTime;
        }

        private void SpawnTillRequired() 
        {
            while (omul && omuls.Count < omulPopulation)
                SpawnOmul();

            while (oilfish && oilfishs.Count < oilfishPopulation)
                SpawnOilfish();

            while (bullfish && bullfishs.Count < bullfishPopulation)
                SpawnBullfish();
        }

        private void SpawnOmul() => Spawn(omul, omuls);
        private void SpawnOilfish() => Spawn(oilfish, oilfishs);
        private void SpawnBullfish() => Spawn(bullfish, bullfishs);

        private void Spawn(GameObject fish, List<GameObject> list) 
        {
            bool spawned = false;
			do 
            {
                Vector2 currentArea = areas[Random.Range(0, areas.Count - 1)].position;
                if (outOfCamera(currentArea)) 
                {
                    Vector2 position = new Vector2(
                        currentArea.x + Random.Range(-distance, distance),
                        currentArea.y + Random.Range(-distance, distance)
                    );
                    var go = Instantiate(fish, position, Quaternion.identity, transform);
                    list.Add(go);
                }
                spawned = true;
            } while (!spawned);
        }

        private bool outOfCamera(Vector2 position) 
        {
            Vector2 viewportPoint = Camera.main.WorldToViewportPoint(position);
            if (viewportPoint.x < 0f || viewportPoint.x > 1f || viewportPoint.y < 0f || viewportPoint.y > 1f)
                return true;
            else
                return false;
		}

        public void RemoveFish(GameObject item, List<GameObject> list) 
        {
            list.RemoveAt(list.IndexOf(item));
        }
    }
}
