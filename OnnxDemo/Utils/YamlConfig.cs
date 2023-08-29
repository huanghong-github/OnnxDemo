﻿namespace OnnxDemo.Utils
{
    public class YamlConfig
    {
        public required string Name { get; set; }
        public required string OnnxPath { get; set; }
        public required string[] Labels { get; set; }
        public float IOUThreshold { get; set; } = 0.5f;
        public float ConfThreshold { get; set; } = 0.5f;
        public int InputWidth { get; set; } = 640;
        public int InputHeight { get; set; } = 640;

        public static Dictionary<string, YamlConfig> ToDict(List<YamlConfig> list)
        {
            Dictionary<string, YamlConfig> dict = new();
            foreach (YamlConfig item in list)
            {
                dict[item.Name] = item;
            }
            return dict;
        }
    }
}