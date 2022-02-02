using System.Collections.Generic;
using UnityEngine;

public class BulletGun : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject GunBullet;
        public int bulletAmount;
    }

    //private Transform Player;
    public List<Pool> pools;

    [SerializeField]
    private float bulletSpeed;

    public Dictionary<string, Queue<GameObject>> poolDictionary;

    private void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for(int i =0; i < pool.bulletAmount ;i++)
            {
                GameObject Bullet = Instantiate(pool.GunBullet);
                Bullet.SetActive(false);
                objectPool.Enqueue(Bullet);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool (string tag, Vector3 position, Quaternion rotation)
    {
        if(!poolDictionary.ContainsKey(tag))
        {
            Debug.Log(tag + " не существует");
            return null;
        }

        GameObject Bullet = poolDictionary[tag].Dequeue();
        Bullet.SetActive(true);
        Bullet.transform.SetPositionAndRotation(position, rotation);

        poolDictionary[tag].Enqueue(Bullet);

        return Bullet;
    }
}