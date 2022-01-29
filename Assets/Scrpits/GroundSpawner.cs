
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] public GameObject GroundTile;
    Vector3 nextSpwanPoint;

    public void SpawnTile(bool spwn,bool engg)
    {
        GameObject temp= Instantiate(GroundTile, nextSpwanPoint, Quaternion.identity);
        nextSpwanPoint = temp.transform.GetChild(1).transform.position;
        if(spwn)
        {
            temp.GetComponent<GroundTile>().SpawnObstace();
            temp.GetComponent<GroundTile>().SpawnCoin();
        }
        if(engg)
        {
            temp.GetComponent<GroundTile>().spawnenergy();
        }

    }
    void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            if (i < 2)
            {
                SpawnTile(false,false);
            }
            if(i%2==0)
            {
                SpawnTile(false,true);
            }
            else
            {
                SpawnTile(true, false);
            }

            }
        

    }

    
}
