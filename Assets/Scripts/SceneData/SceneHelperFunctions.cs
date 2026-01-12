using UnityEngine;

public static class SceneHelperFunctions
{
    public static readonly int numberOfLevels = 1;

    public static int GetRecordsIndexFromSceneName(string sceneName)
    {
        switch (sceneName)
        {
            case "Level 1":
                return 0;
            default:
                return -1;
        }
    }
}
