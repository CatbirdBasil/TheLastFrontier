
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;


namespace TLFUILogic
{
    public class FileSaveSystem : ISaveSystem
    {
        
        public void saveInfo(PlayerData playerData)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location+"/playerInfo.fun");
            FileStream saveStrim = new FileStream(path,FileMode.Create);
            
            PlayerDataForSafe data = new PlayerDataForSafe(playerData);
            formatter.Serialize(saveStrim,data);
            saveStrim.Close();
        }

        
        public PlayerData getInfo()
        {
            string path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location+"/playerInfo.fun");
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream saveStrim = new FileStream(path,FileMode.Open);
                PlayerDataForSafe playerData = formatter.Deserialize(saveStrim) as PlayerDataForSafe;
                return new PlayerData(playerData);

            }
            else
            {
                return new PlayerData();
            }
        }
    }
}