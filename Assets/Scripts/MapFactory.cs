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
    public Transform home;
    public int homeSize;
    public bool[,] isGroundMap;
    public Vector3 distanceScaleValue = Vector3.one;
    public float beachMinDistance;

    //string savePath = @"C:\test\MapFile.txt";
    int endPosX;
    int endPosZ;
    IMapObject[,] map;
    GameObject parent;

    #endregion

    #region Unity Methods
    // Use this for initialization
    void Start()
    {
        isGroundMap = new bool[mapSize * 2, mapSize * 2];
        //if (!System.IO.File.Exists(savePath))
        GenerateNewMap();
        //else
        //    LoadFromSaveFile();
    }

    //TESTING STUFF TO BE REMOVED
    int count = 0;

    private void Update()
    {
        count++;
        if (count == 100)
            SaveMap();
    }
    //TESTING STUFF TO BE REMOVED

    #endregion

    #region Methods

    private void GenerateNewMap()
    {
        //Basis Werte initialisieren
        map = new IMapObject[mapSize, mapSize];
        parent = GameObject.Find("MapFactory");

        CreateGround();
        //CreateBorders();
        CreateOutlands();

        // Basis erstellen:
        Instantiate(home, new Vector3(spawnPosX * distanceScale, 0, spawnPosZ * distanceScale), Quaternion.identity);
        for (int i = spawnPosX; i < spawnPosX + homeSize; i++)
        {
            for (int j = spawnPosZ; j < spawnPosZ + homeSize; j++)
            {
                map[i, j] = new Spawn();
            }
        }
        // Spieler erstellen:
        Instantiate(player, new Vector3(spawnPosX * distanceScale, 0 + player.Find("m01_02").GetComponent<SkinnedMeshRenderer>().sharedMesh.bounds.extents.y * player.transform.localScale.y, spawnPosZ * distanceScale), Quaternion.identity);

        CreateLayout();
    }

    private void LoadFromSaveFile()
    {
        /* map = new IMapObject[mapSize, mapSize];
         parent = GameObject.Find("MapFactory");

         CreateGround();
         CreateBorders();
         CreateOutlands();

         // Basis erstellen:
         Instantiate(home, new Vector3(spawnPosX * distanceScale, 0, spawnPosZ * distanceScale), Quaternion.identity);
         for (int i = spawnPosX; i < spawnPosX + homeSize; i++)
         {
             for (int j = spawnPosZ; j < spawnPosZ + homeSize; j++)
             {
                 map[i, j] = new Spawn();
             }
         }
         // Spieler erstellen:
         Instantiate(player, new Vector3(spawnPosX * distanceScale, 1, spawnPosZ * distanceScale), Quaternion.identity);

         //Objekte aus der SaveFile lesen und erstellen:
         string[] mapStringArray = System.IO.File.ReadAllLines(savePath);
         string mapString = string.Join("", mapStringArray);
         LoadObjectsFromSaveFile(mapString);*/
    }

    private void LoadObjectsFromSaveFile(string mapString)
    {
        /*  int counter = 0;
          string[] objects = mapString.Split(';');
          for (int i = 0; i < mapSize; i++)
          {
              for (int j = 0; j < mapSize; j++)
              {
                  switch (objects[counter])
                  {
                      case "Stone":
                         Instantiate((masterRock.GetTransform()), new Vector3((i * distanceScale) + masterRock.XOffset,
                          yOffset, (j * distanceScale) + masterRock.ZOffset), Quaternion.identity);
                          map[i, j] = masterRock;
                          break;
                      case "Tree":
                          Instantiate((masterTree.GetTransform()), new Vector3((i * distanceScale) + masterTree.XOffset,
                        yOffset, (j * distanceScale) + masterTree.ZOffset), Quaternion.identity);
                          map[i, j] = masterTree;
                          break;
                      case "House":
                          Instantiate((masterHouse.GetTransform()), new Vector3((i * distanceScale) + masterHouse.XOffset,
                        yOffset, (j * distanceScale) + masterHouse.ZOffset), Quaternion.identity);
                          map[i, j] = masterHouse;
                          break;
                      default:
                          //Wenn leer oder spawn: nix passiert
                          break;
                  }
                  counter++;
              }
          } */
    }

    private void SaveMap()
    {
        /* string mapString = "";

         for (int i = 0; i < mapSize; i++)
         {
             for (int j = 0; j < mapSize; j++)
             {
                 mapString += map[i, j].SaveString + ";";
             }
         }

         System.IO.StreamWriter writer = System.IO.File.CreateText(savePath);
         writer.WriteLine(mapString);
         writer.Close(); */
    }


    private bool[,] DrawCircle(int x0, int y0, int radius)
    {
        //int x = radius;
        //int y = 0;
        //int err = 0;
        bool[,] result = new bool[mapSize * 2, mapSize * 2];

        //while (x >= y)
        //{
        //    result[x0 + x, y0 + y] = true;
        //    result[x0 + y, y0 + x] = true;
        //    result[x0 - y, y0 + x] = true;
        //    result[x0 - x, y0 + y] = true;
        //    result[x0 - x, y0 - y] = true;
        //    result[x0 - y, y0 - x] = true;
        //    result[x0 + y, y0 - x] = true;
        //    result[x0 + x, y0 - y] = true;

        //    y += 1;
        //    if (err <= 0)
        //    {
        //        err += 2 * y + 1;
        //    }
        //    else
        //    {
        //        x -= 1;
        //        err += 2 * (y - x) + 1;
        //    }
        //}
        //return result;
        for (int y = -radius; y <= radius; y++)
            for (int x = -radius; x <= radius; x++)
                if (x * x + y * y <= radius * radius)
                    result[x0 + x, y0 + y] = true;
        return result;
    }


    private void CreateGround()
    {
        bool[,] res = DrawCircle(spawnPosX, spawnPosZ, 18);
        for (int j = 0; j < mapSize * 2; j++)
        {
            for (int k = 0; k < mapSize * 2; k++)
            {
                if (res[j, k])
                {
                    Transform placedObj = Instantiate(masterGroundTile.GetTransform(), new Vector3((j * distanceScale) + masterGroundTile.XOffset, yOffset,
                        (k * distanceScale) + masterGroundTile.ZOffset), Quaternion.identity);
                    placedObj.tag = "Ground";
                    placedObj.SetParent(parent.transform);
                    if (j < mapSize - 1 && k < mapSize - 1)
                    {
                        map[j, k] = masterGroundTile;
                        isGroundMap[j, k] = true;
                    }
                }
            }
        }

        bool[,] res2 = DrawCircle(spawnPosX, spawnPosZ, 25);
        for (int j = 0; j < mapSize * 2; j++)
        {
            for (int k = 0; k < mapSize * 2; k++)
            {
                if (res2[j, k] && isGroundMap[j, k] == false)
                {
                    Transform placedObj = Instantiate(masterGroundTile.Beach, new Vector3((j * distanceScale) + masterGroundTile.XOffset, yOffset,
                        (k * distanceScale) + masterGroundTile.ZOffset), Quaternion.identity);
                    placedObj.tag = "Beach";

                    placedObj.SetParent(parent.transform);
                    if (j < mapSize - 1 && k < mapSize - 1)
                    {
                        map[j, k] = masterGroundTile;
                        isGroundMap[j, k] = false;
                    }

                    /**
                        * START
                        */

                    ////Oriantate towards heightpoint
                    //Vector3 heightPointPosition = new Vector3(75, 10, 75);

                    //float distance = Vector3.Distance(placedObj.transform.position, heightPointPosition);

                    ////Move
                    //float yPosition = heightPointPosition.y - distance / 5.55f;
                    //placedObj.transform.position = Vector3.MoveTowards(placedObj.position, heightPointPosition, 8f);
                    //placedObj.position = new Vector3(placedObj.position.x, yPosition, placedObj.position.z);


                    ////Rotation
                    //Vector3 targetDir = heightPointPosition - placedObj.transform.position;
                    //Vector3 newDir = Vector3.RotateTowards(placedObj.transform.position, targetDir, 3.5f, 0.0f);
                    //Vector3 rotation = Quaternion.LookRotation(newDir, placedObj.up).eulerAngles;

                    //placedObj.eulerAngles = rotation;


                    ////Scale to fill empty space
                    //placedObj.transform.localScale = new Vector3(
                    //    placedObj.transform.localScale.x + (distance * distanceScaleValue.x),
                    //    placedObj.transform.localScale.y + (distance * distanceScaleValue.y),
                    //    placedObj.transform.localScale.z + (distance * distanceScaleValue.z));

                    //float newDistance = Vector3.Distance(placedObj.position, heightPointPosition);

                    //if(newDistance < beachMinDistance)
                    //{
                    //    Destroy(placedObj.gameObject); 
                    //}

                    /**
                        * END
                        */
                }
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
                    Transform placedObj = Instantiate(wall, new Vector3((i - 1) * distanceScale, 0, j * distanceScale), Quaternion.identity);
                    placedObj.SetParent(parent.transform);
                }
                if (j == 0)
                {
                    Transform placedObj = Instantiate(wall, new Vector3((i - 1) * distanceScale, 0, (j - 1) * distanceScale), Quaternion.identity);
                    placedObj.Rotate(new Vector3(0, -90, 0));
                    placedObj.SetParent(parent.transform);
                }
                if (i == mapSize - 1)
                {
                    Transform placedObj = Instantiate(wall, new Vector3(i * distanceScale, 0, (j - 1) * distanceScale), Quaternion.identity);
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
                    if (!isGroundMap[x, z] && (currPair.Key.GetType()) == typeof(Assets.Scripts.Map.Tree))
                    {
                        GameObject placedObj = Instantiate(((Assets.Scripts.Map.Tree)currPair.Key).Palm.gameObject, new Vector3((x * distanceScale) + currPair.Key.XOffset,
                            yOffset, (z * distanceScale) + currPair.Key.ZOffset), Quaternion.identity);
                        placedObj.transform.SetParent(parent.transform);
                    }
                    else
                    {
                        GameObject placedObj = Instantiate(currPair.Key.GetTransform().gameObject, new Vector3((x * distanceScale) + currPair.Key.XOffset,
                            yOffset, (z * distanceScale) + currPair.Key.ZOffset), Quaternion.identity);
                        placedObj.transform.SetParent(parent.transform);
                    }

                    map[x, z] = currPair.Key;
                    placed++;
                }
            }
        }
    }

    private bool ShouldPlaceObject(int x, int z)
    {
        if (map[x, z] == null)
            return false;
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
        try
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
        catch
        {
            return true;
        }
    }
    #endregion 
}
