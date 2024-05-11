using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PU_Manager : MonoBehaviour
{
    public Transform spawnArea;
    public int MaxPowerUp;
    public int SpawnInterval;
    public Vector2 PU_AreaMax, PU_AreaMin;
    public List<GameObject> PU_TemplateList;
    List<GameObject> PU_List;

    private float timer;

    private void Start()
    {
        PU_List = new List<GameObject>();
        timer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > SpawnInterval)
        {
            GeneratePU();
            timer -= SpawnInterval;
        }
    }

    public void GeneratePU()
    {
        GeneratePUpos(new Vector2(
            Random.Range(PU_AreaMin.x, PU_AreaMax.x), 
            Random.Range(PU_AreaMin.y, PU_AreaMax.y)));
    }

    public void GeneratePUpos(Vector2 pos)
    {
        //Don't spawn if exceed max amount of spawn
        if(PU_List.Count >= MaxPowerUp)
        {
            return;
        }

        //Don't spawn anything beyond area limit
        if(pos.x < PU_AreaMin.x || pos.x > PU_AreaMax.x ||
            pos.y < PU_AreaMin.y || pos.y > PU_AreaMax.y)
        {
            return;
        }

        //Taking the index from the template list, if there's 2, will spawn one of them randomly
        int randomIndex = Random.Range(0, PU_TemplateList.Count);
        //Spawn the object
        GameObject PowerUp = Instantiate(PU_TemplateList[randomIndex], pos, Quaternion.identity, spawnArea);
        //Set active the spawned object
        PowerUp.SetActive(true);
        //Adding a list of spawned power up
        PU_List.Add(PowerUp);
    }

    public void RemovePowerUp(GameObject PowerUp)
    {
        PU_List.Remove(PowerUp);
        Destroy(PowerUp);
    }

    public void RemoveAllPowerUp()
    {
        while(PU_List.Count > 0)
        {
            RemovePowerUp(PU_List[0]);
        }
    }

}
