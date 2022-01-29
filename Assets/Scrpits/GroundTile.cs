
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    [SerializeField] GroundSpawner groundSpawner;
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        
    }
    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile(true,true);
        Destroy(gameObject, 2);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject obstaclePrefab;
    public void SpawnObstace()
    {
        int obstaceSpanIndex = Random.Range(2, 5);
        Transform spanPoint = transform.GetChild(obstaceSpanIndex).transform;
        Instantiate(obstaclePrefab, spanPoint.position, Quaternion.identity, transform);     
    }
    public GameObject Coinprefab;
    public void SpawnCoin()
    {
        int coinsToSpawn = 4;
        for (int i = 0; i < coinsToSpawn; i++)
        {
            GameObject temp= Instantiate(Coinprefab,transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }

    }
    public GameObject EnergyCubeprefab;
    public void spawnenergy()
    {
        
        GameObject temp1 = Instantiate(EnergyCubeprefab, transform);
        temp1.transform.position = GetRandomPointInCollider(GetComponent<Collider>());

    }
    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(Random.Range(collider.bounds.min.x, collider.bounds.max.x), 
            Random.Range(collider.bounds.min.y, collider.bounds.max.y), 
            Random.Range(collider.bounds.min.z, collider.bounds.max.z));
        if(point!=collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }
        point.y = 1;
        return point;

    }
}
