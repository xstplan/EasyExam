using Avalonia.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XST.Exam.Helper
{
    public class IniFileHelper
    {
        // 读取INI文件中的指定节(section)和键(key)的值
        public static string ReadValue(string filePath, string section, string key)
        {
            string value = null;

            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                bool sectionFound = false;

                while ((line = reader.ReadLine()) != null)
                {
                    // 去除空格和注释
                    line = line.Trim();
                    if (line.StartsWith(";") || string.IsNullOrWhiteSpace(line))
                        continue;

                    if (line.StartsWith("[") && line.EndsWith("]"))
                    {
                        if (line.Substring(1, line.Length - 2).Equals(section, StringComparison.OrdinalIgnoreCase))
                        {
                            sectionFound = true;
                        }
                        else
                        {
                            sectionFound = false;
                        }
                    }
                    else if (sectionFound)
                    {
                        string[] parts = line.Split(new char[] { '=' }, 2);
                        if (parts.Length == 2 && parts[0].Trim().Equals(key, StringComparison.OrdinalIgnoreCase))
                        {
                            value = parts[1].Trim();
                            break;
                        }
                    }
                }
            }

            return value;
        }

        // 写入INI文件中的指定节(section)和键(key)的值
        public static void WriteValue(string filePath, string section, string key, string value)
        {
            List<string> lines = new List<string>();

            // 如果文件存在，则读取内容
            if (File.Exists(filePath))
            {
                lines.AddRange(File.ReadAllLines(filePath));
            }

            // 查找或创建节(section)
            bool sectionFound = false;
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Trim().StartsWith("[") && lines[i].Trim().EndsWith("]"))
                {
                    if (lines[i].Substring(1, lines[i].Length - 2).Equals(section, StringComparison.OrdinalIgnoreCase))
                    {
                        sectionFound = true;
                        break;
                    }
                }
            }
            if (!sectionFound)
            {
                lines.Add("[" + section + "]");
            }

            // 查找或创建键值对
            sectionFound = false;
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Trim().StartsWith("[") && lines[i].Trim().EndsWith("]"))
                {
                    if (lines[i].Substring(1, lines[i].Length - 2).Equals(section, StringComparison.OrdinalIgnoreCase))
                    {
                        sectionFound = true;
                    }
                    else
                    {
                        sectionFound = false;
                    }
                }
                else if (sectionFound)
                {
                    string[] parts = lines[i].Split(new char[] { '=' }, 2);
                    if (parts.Length == 2 && parts[0].Trim().Equals(key, StringComparison.OrdinalIgnoreCase))
                    {
                        lines[i] = key + "=" + value;
                        sectionFound = false;
                        break;
                    }
                }
            }
            if (!sectionFound)
            {
                lines.Add(key + "=" + value);
            }

            // 写入文件
            File.WriteAllLines(filePath, lines);
        }
    }

}
