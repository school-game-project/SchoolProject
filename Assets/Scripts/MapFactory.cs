using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Map;

public class MapFactory : MonoBehaviour
{
    #region Props and Fields

    public Assets.Scripts.Map.Tree masterTree;
    public Rock masterRock;
    public GroundTile masterGroundTile;
    public House masterHouse;
    public int mapSize;
    public int treeThinner;
    public int rockThinner;
    public int yOffset;
    public int houseCount;
    public int distanceScale;
    public int spawnPosX;
    public int spawnPosZ;
    public Transform player;
    public Transform wall;

    int endPosX;
    int endPosZ;
    IMapObject[,] map;
    GameObject parent;

    #endregion

    #region Unity Methods
    // Use this for initialization
    void Start()
    {
        //Basis Werte initialisieren
        map = new IMapObject[mapSize, mapSize];
        parent = GameObject.Find("MapFactory");

        CreateGround();
        CreateBorders();
        CreateOutlands();

        // Spieler erstellen:
        Instantiate(player, new Vector3(spawnPosX * distanceScale, 1, spawnPosZ * distanceScale), Quaternion.identity);

        CreateLayout();
    }

    #endregion

    #region Methods

    private void CreateGround()
    {
        for(int i = 0; i < mapSize; i++)
        {
            for (int j = 0; j < mapSize; j++)
            {
                Transform placedObj = Instantiate(masterGroundTile.GetTransform(), new Vector3((i*distanceScale) + masterGroundTile.XOffset, yOffset, 
                    (j*distanceScale) + masterGroundTile.ZOffset), Quaternion.identity);
                placedObj.SetParent(parent.transform);
                map[i, j] = masterGroundTile;
            }
        }
    }

    private void CreateBorders()
    {
        for (int i = 0; i < mapSize; i++)
        {
            for (int j = 0; j < mapSize; j++)
            {
                if (i == 0)
                {
                    Transform placedObj = Instantiate(wall, new Vector3((i-1) * distanceScale, 0, j * distanceScale), Quaternion.identity);
                    placedObj.SetParent(parent.transform);
                }
                if (j == 0)
                {
                    Transform placedObj = Instantiate(wall, new Vector3((i-1) * distanceScale, 0, (j-1) * distanceScale), Quaternion.identity);
                    placedObj.Rotate(new Vector3(0, -90, 0));
                    placedObj.SetParent(parent.transform);
                }
                if(i == mapSize - 1)
                {
                    Transform placedObj = Instantiate(wall, new Vector3(i * distanceScale, 0, (j-1) * distanceScale), Quaternion.identity);
                    placedObj.Rotate(new Vector3(0, 180, 0));
                    placedObj.SetParent(parent.transform);

                }
                if (j == mapSize - 1)
                {
                    Transform placedObj = Instantiate(wall, new Vector3(i * distanceScale, 0, j * distanceScale), Quaternion.identity);
                    placedObj.Rotate(new Vector3(0, 90, 0));
                    placedObj.SetParent(parent.transform);
                }
            }
        }
    }

    private void CreateOutlands()
    {
        //TODO create stuff outside borders
    }

    private void CreateLayout()
    {
        // Place objects to create layout:
        Dictionary<IMapObject, int> objectDistribution = new Dictionary<IMapObject, int>();

        int treeCount = ((mapSize) * (mapSize)) / treeThinner;
        objectDistribution.Add(masterTree, treeCount);

        int rockCount = ((mapSize) * (mapSize)) / rockThinner;
        objectDistribution.Add(masterRock, rockCount);

        objectDistribution.Add(masterHouse, houseCount);

        PlaceObjects(objectDistribution, 0);
    }


    #endregion

    #region HelperMethods

    private void PlaceObjects(Dictionary<IMapObject, int> objectDistribution, int placed)
    {
        //TODO loop through tiletypes
        foreach (KeyValuePair<IMapObject, int> currPair in objectDistribution)
        {
            placed = 0;
            int toPlace = currPair.Value;
            while (toPlace != placed)
            {
                int x = Random.Range(1, mapSize - 2);
                int z = Random.Range(1, mapSize - 2);

                if (ShouldPlaceObject(x, z))
                {
                    Transform placedObj = Instantiate((currPair.Key.GetTransform()), new Vector3((x*distanceScale) + currPair.Key.XOffset, 
                        yOffset, (z*distanceScale) + currPair.Key.ZOffset), Quaternion.identity);
                    placedObj.SetParent(parent.transform);
                    

                    map[x, z] = currPair.Key;
                    placed++;
                }
            }
        }
    }

    private bool ShouldPlaceObject(int x, int z)
    {
        if (map[x, z].GetType() != typeof(GroundTile))
            return false;
        if (!CanReachObjectives(x, z))
            return false;
        else
            return true;
    }

    private bool CanReachObjectives(int x, int z)
    {
        //temporary set obstacle in map:
        IMapObject origin = map[x, z];
        map[x, z] = masterRock;
        if (IsPathPossible(spawnPosX, spawnPosZ, new bool[mapSize, mapSize]))
        {
            map[x, z] = origin;
            return true;
        }
        else
        {
            map[x, z] = origin;
            return false;
        }
    }

    private bool IsPathPossible(int x, int z, bool[,] visited)
    {
        visited[x, z] = true;
        if (x == endPosX && z == endPosZ)
        {
            return true;
        }
        else
        {
            if (x != 0 && !map[x - 1, z].IsObstacle && !visited[x - 1, z])
            {
                if (IsPathPossible(x - 1, z, visited))
                    return true;
            }
            if (x != mapSize - 1 && !map[x + 1, z].IsObstacle && !visited[x + 1, z])
            {
                if (IsPathPossible(x + 1, z, visited))
                    return true;
            }
            if (z != 0 && !map[x, z - 1].IsObstacle && !visited[x, z - 1])
            {
                if (IsPathPossible(x, z - 1, visited))
                    return true;
            }
            if (z != mapSize - 1 && !map[x, z + 1].IsObstacle && !visited[x, z + 1])
            {
                if (IsPathPossible(x, z + 1, visited))
                    return true;
            }
            return false;
        }
    }
    #endregion 
}
