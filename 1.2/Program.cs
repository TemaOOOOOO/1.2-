using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> d1 = new Dictionary<string, int> { { "a", 100 }, { "b", 200 }, { "c", 300 } };
        Dictionary<string, int> d2 = new Dictionary<string, int> { { "a", 300 }, { "b", 200 }, { "d", 400 } };
        Dictionary<string, int> mergedDict = new Dictionary<string, int>();

        foreach (var kvp in d1)
        {
            if (d2.ContainsKey(kvp.Key))
                mergedDict[kvp.Key] = kvp.Value + d2[kvp.Key];
            else
                mergedDict[kvp.Key] = kvp.Value;
        }
        foreach (var kvp in d2)
        {
            if (!mergedDict.ContainsKey(kvp.Key))
                mergedDict[kvp.Key] = kvp.Value;
        }
        string jsonResult = JsonSerializer.Serialize(mergedDict);
        Console.WriteLine(jsonResult);
        File.WriteAllText("output.json",jsonResult);
    }
}

