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

    int spawnPosX;
    int spawnPosZ;
    int endPosX;
    int endPosZ;
    IMapObject[,] map;

    #endregion

    #region Unity Methods
    // Use this for initialization
    void Start()
    {
        //Basis Werte initialisieren
        map = new IMapObject[mapSize, mapSize];

        CreateGround();
        CreateBorders();
        CreateOutlands();
        CreateLayout();
    }

    // Update is called once per frame
    void Update()
    {

    }

    #endregion

    #region Methods

    private void CreateGround()
    {
        for(int i = 0; i < mapSize; i++)
        {
            for (int j = 0; j < mapSize; j++)
            {
                Instantiate(masterGroundTile.GetTransform(), new Vector3((i*distanceScale) + masterGroundTile.XOffset, yOffset, 
                    (j*distanceScale) + masterGroundTile.ZOffset), Quaternion.identity);
                map[i, j] = masterGroundTile;
            }
        }
    }

    private void CreateBorders()
    {
        //TODO adjust
        for (int i = 0; i < mapSize; i++)
        {
            for (int j = 0; j < mapSize; j++)
            {
                if (i == 0 || j == 0 || i == mapSize - 1 || j == mapSize - 1)
                {
                    //Instantiate(block, new Vector3(i - offSet, 1, j - offSet), Quaternion.identity);
                    //map[i, j] = wert;
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
                    Instantiate((currPair.Key.GetTransform()), new Vector3((x*distanceScale) + currPair.Key.XOffset, 
                        yOffset, (z*distanceScale) + currPair.Key.ZOffset), Quaternion.identity);
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
