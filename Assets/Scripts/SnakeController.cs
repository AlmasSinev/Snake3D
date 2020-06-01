using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public List<Transform> tails;
    public float BonesDistance;
    public GameObject BonePrefab;
    public GameObject FoodPrefab;
    [Range(0, 4)]
    public float Speed;
    private Transform _transform;

    public GameObject Mcamera;
    public GameObject Parent;
    public GameObject PanelDead;

    public Transform spawnZone;
    public GameObject objToSpawn;

    public float maxX;
    public float minX;
    public float maxZ;
    public float minZ;


    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<Transform>();

        maxX = spawnZone.position.x + 20;
        minX = spawnZone.position.x - 20;

        maxZ = spawnZone.position.z + 20;
        minZ = spawnZone.position.z - 20;
    }

    // Update is called once per frame
    void Update()
    {
        MoveSnake(_transform.position + _transform.forward * Speed);

        float angel = Input.GetAxis("Horizontal") * 4;
        _transform.Rotate(0, angel, 0);
    }

    private void MoveSnake (Vector3 newPosition)
    {
        float sqrDistance = BonesDistance * BonesDistance;
        Vector3 previusPosition = _transform.position;

        foreach (var bone in tails)
        {
            if ((bone.position - previusPosition).sqrMagnitude > sqrDistance) 
            {
                var temp = bone.position;
                bone.position = previusPosition;
                previusPosition = temp;
            } 
            else
            {
                break;
            }
        }

        _transform.position = newPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "RAMIL")
        {
            Destroy(collision.gameObject);

            var bone = Instantiate(BonePrefab);
            tails.Add(bone.transform);

            Vector3 spawnPos = new Vector3(Random.Range(minX, maxX), bone.transform.position.y, Random.Range(minZ, maxZ));
            Instantiate(objToSpawn, spawnPos, Quaternion.identity);
        }
        else if (collision.gameObject.tag == "Border" )
        {
            PanelDead.SetActive(true);
            Screen.lockCursor = false;
            Mcamera.SetActive(true);
            Mcamera.transform.parent = Parent.transform;
            //Destroy(gameObject);
            Speed = 0;
        }
    }
}
