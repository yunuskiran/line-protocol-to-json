namespace Library
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using System.Text.RegularExpressions;

    public static class Extensions
    {
        public static void Convert(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return;

            var lines = input.Split('\n');
            if (lines.Any())
                return;

            foreach (var line in lines)
            {
                var jsonItem = new JsonItem();
                if (string.IsNullOrWhiteSpace(line.Split(',')[0]))
                    continue;

                if (string.IsNullOrWhiteSpace(line.Split(',')[1]))
                    continue;

                jsonItem.measurement = line.Split(',')[0];
                if (line.Split(',')[1] == null)
                    continue;

                var tagsFieldsTimestamp = Regex.Replace(line.Split(',')[1], @"[^0-9a-zA-Z]+", "");
                if (string.IsNullOrWhiteSpace(tagsFieldsTimestamp))
                    continue;

                if (Regex.IsMatch(tagsFieldsTimestamp, @"\w+.+\s*=\w+\s*\w+\s*\w+\s*=\w+\s*\d+\s*"))
                {
                    //tags-fields-timestamp
                }
                else if (Regex.IsMatch(tagsFieldsTimestamp, @"\w+.+\s*=\w+\s*\w+\s*\w+\s*=\w+"))
                {
                    //tags-fields
                }
                else if (Regex.IsMatch(tagsFieldsTimestamp, @"\w+.+\s*=\w+\s*\d+\s*"))
                {
                    //fields-timestamp
                }
                else if (Regex.IsMatch(tagsFieldsTimestamp, @"\w+.+\s*=\w+"))
                {
                    //fields
                }
                else
                {
                    //error
                }
            }
        }
    }

    public class JsonItem
    {
        public string measurement { get; set; }
        public List<tag> tags { get; set; }
        public List<field> fields { get; set; }
        public string timestamp { get; set; }
    }

    public class tag
    {
        public string key { get; set; }
        public string value { get; set; }
    }

    public class field
    {
        public string key { get; set; }
        public object value { get; set; }
    }
}
