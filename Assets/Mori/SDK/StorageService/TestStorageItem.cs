using System.Collections.Generic;
using Newtonsoft.Json;

namespace Mori.SDK.StorageService
{
    public class TestStorageItem
    {
        [JsonProperty(PropertyName = "str")] public string StringParameter { get; set; }
        [JsonProperty(PropertyName = "dic")] public Dictionary<string, int> DictionaryParameter { get; set; }
    }
}
