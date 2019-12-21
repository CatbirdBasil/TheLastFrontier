using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace TLFUILogic
{
    public class FileSaveSystem : ISaveSystem
    {
        // private string MacPath = "/Users/annatsytsyluik/Desktop";
        public void saveInfo(PlayerData playerData)
        {
            var formatter = new BinaryFormatter();
            var path = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location + "/playerInfo.fun");
            //string path = System.IO.Path.GetDirectoryName(MacPath + "/playerInfo.fun");
            var saveStrim = new FileStream(path, FileMode.Create);

            var data = new PlayerDataForSafe(playerData);
            formatter.Serialize(saveStrim, data);
            saveStrim.Close();
        }


        public PlayerData getInfo()
        {
            // string path = System.IO.Path.GetDirectoryName(MacPath + "/playerInfo.fun");
            var path = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location + "/playerInfo.fun");
            if (File.Exists(path))
            {
                var formatter = new BinaryFormatter();
                var saveStrim = new FileStream(path, FileMode.Open);
                var playerData = formatter.Deserialize(saveStrim) as PlayerDataForSafe;

                PlayerData.UpdatePlayerData(playerData);
            }

            return PlayerData.Instance;
        }
    }
}