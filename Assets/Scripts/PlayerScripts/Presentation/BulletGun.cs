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

    public List<Pool> pools;

    [SerializeField]
    private float bulletSpeed;


    private void Awake()
    {
        PlayerLogicMain.bulletGun = this;
    }

    private void Start()
    {
        PlayerLogicMain.poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for(int i =0; i < pool.bulletAmount ;i++)
            {
                GameObject Bullet = Instantiate(pool.GunBullet);
                Bullet.SetActive(false);
                objectPool.Enqueue(Bullet);
            }

            PlayerLogicMain.poolDictionary.Add(pool.tag, objectPool);
        }
    }
}