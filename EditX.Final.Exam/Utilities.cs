﻿using EditX.Final.Exam.Models.Warehouse;
using System.Reflection;
using System.Text.Json;

namespace EditX.Final.Exam
{
    internal static class Utilities
    {
        internal static Stream ReadResourceContentToStream(string filename)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = $"EditX.Final.Exam.Resources.{filename}";
            string expectedOutput = string.Empty;                 

            return assembly.GetManifestResourceStream(resourceName);
        }

        internal static async Task<IEnumerable<T>?> ReadPatientsFromJSON<T>(string filename)
        {
            Stream inputJSON = ReadResourceContentToStream(filename);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return await JsonSerializer.DeserializeAsync<IEnumerable<T>>(inputJSON, options);
        }

        internal static async Task<List<WarehouseNode>> ReadWarehouseInventoryFromJSON(string filename)
        {
            Stream inputJSON = ReadResourceContentToStream(filename);

            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            return await JsonSerializer.DeserializeAsync<List<WarehouseNode>>(inputJSON, options);
        }

        internal static string ConvertWarehouseInventoryToJSON(List<WarehouseNode> list)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(list, options);

            return jsonString;
        }
    }
}