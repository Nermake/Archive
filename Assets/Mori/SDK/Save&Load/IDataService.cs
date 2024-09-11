using System.Collections.Generic;

namespace Mori.SDK.SaveSystem
{
    public interface IDataService
    {
        public void Save(GameData data, bool overWrite = true);
        public GameData Load(string name);
        public void Delete(string name);
        public void DeleteAll();
        public IEnumerable<string> ListSaves();
    }
}