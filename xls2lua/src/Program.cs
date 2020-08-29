using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using ExcelDataReader;
using Mono.Options;

namespace xls2lua
{
    class Program
    {
        static Dictionary<string, string> type_map = new Dictionary<string, string>();
        static bool args_help = false;
        static string search_path = null;
        static string search_pattern = "*.xls";
        static string file_out = null;
        static List<string> blacklist = new List<string>();
        static List<string> whitelist = new List<string>();

        static void Main(string[] args)
        {
            var options = new OptionSet {
                { "h|help", "show this message and exit", h => args_help = h != null },
                { "search_path=", "搜索路径",  s => search_path = s },
                { "search_pattern=", "搜索模式, 默认值: \"*.xls\"",  s => search_pattern = s },
                { "file_out=", "输出文件",  s => file_out = s },
                { "blacklist=", "黑名单, 表名",  s => blacklist.Add(s) },
                { "whitelist=", "白名单, 表名",  s => whitelist.Add(s) },
            };
            List<string> extra;
            try
            {
                extra = options.Parse(args);
            }
            catch (Exception)
            {
                Console.WriteLine("Oops...参数解析错误\n\n");
                options.WriteOptionDescriptions(Console.Out);
                return;
            }

            if (args_help)
            {
                options.WriteOptionDescriptions(Console.Out);
                return;
            }

            if (null == search_path || "" == search_path || !Directory.Exists(search_path))
            {
                Console.WriteLine("Oops...请指定正确的搜索路径\n\n");
                return;
            }

            if (null == file_out || "" == file_out || !File.Exists(file_out))
            {
                Console.WriteLine("Oops...请指定正确的输出文件\n\n");
                return;
            }

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            type_map.Add("int", "number");
            type_map.Add("str", "string");
            type_map.Add("bool", "boolean");
            type_map.Add("list", "table");

            StringBuilder sb = new StringBuilder();

            string[] files = Directory.GetFiles(search_path, search_pattern, SearchOption.TopDirectoryOnly);

            foreach (string file in files)
            {
                GenConfigType(file, sb);
            }

            File.WriteAllText(file_out, sb.ToString());
        }

        static void GenConfigType(string xls_file, StringBuilder sb)
        {
            using (var stream = File.Open(xls_file, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet();

                    string cfg_name = GetConfigName(result.Tables[0], 0, 0);

                    if (blacklist.Contains(cfg_name))
                    {
                        return;
                    }
                    if (0 < whitelist.Count && !whitelist.Contains(cfg_name))
                    {
                        return;
                    }

                    List<int> fms = GetFieldModifier(result.Tables[1], 0);
                    List<string> fts = GetFieldType(result.Tables[1], 1);
                    List<string> fns = GetFieldName(result.Tables[1], 2);

                    if (fms.Count != fts.Count || fms.Count != fns.Count)
                    {
                        return;
                    }

                    sb.AppendLine("\n---@class " + cfg_name + " @ " + Path.GetFileName(xls_file));

                    int len = fms.Count;

                    for (int i = 0; i < len; i++)
                    {
                        if (0 != fms[i] && 1 != fms[i])
                        {
                            continue;
                        }

                        if ("" == fts[i] || "" == fns[i])
                        {
                            continue;
                        }

                        string type_str;
                        if (type_map.TryGetValue(fts[i], out type_str))
                        {
                            sb.AppendLine("---@field " + fns[i] + " " + type_str);
                        }
                        else
                        {
                            if ("atom" == fts[i])
                            {
                                List<string> keys = new List<string>();
                                List<string> values = new List<string>();
                                GetValuesAt(result.Tables[1], 3, 0, keys);
                                GetValuesAt(result.Tables[1], 3, 1, values);

                                int l = keys.Count;

                                for (int j = 0; j < l; j++)
                                {
                                    if ("" == keys[j] || "" == values[j])
                                    {
                                        continue;
                                    }

                                    bool out_bool;
                                    int out_int;
                                    float out_float;

                                    string value_type = "table";
                                    if ("" == values[j] || values[j].Contains(','))
                                    {
                                        value_type = "table";
                                    }
                                    else if (bool.TryParse(values[j], out out_bool))
                                    {
                                        value_type = "boolean";
                                    }
                                    else if (int.TryParse(values[j], out out_int) || float.TryParse(values[j], out out_float))
                                    {
                                        value_type = "number";
                                    }
                                    else
                                    {
                                        value_type = "string";
                                    }

                                    sb.AppendLine("---@field " + keys[j] + " " + "{ " + GetValuesAt(result.Tables[1], 2, 1, new List<string>())[0] + ": " + value_type + " }");
                                }

                                continue;
                            }
                        }
                    }
                }
            }
        }

        static List<string> GetValuesAt(DataTable table, int row, int column, List<string> values)
        {
            int count_row = table.Rows.Count;

            for (; row < count_row; row++)
            {
                var value = table.Rows[row].Field<object>(table.Columns[column]);
                if (null == value)
                {
                    values.Add("");
                }
                else
                {
                    values.Add(value.ToString());
                }
            }

            return values;
        }

        static string GetConfigName(DataTable table, int r, int c)
        {
            DataRow row = table.Rows[r];
            var value = row.Field<object>(table.Columns[c]);
            return value.ToString().Split('=')[1];
        }

        static List<int> GetFieldModifier(DataTable table, int r)
        {
            List<int> result = new List<int>();

            DataRow row = table.Rows[r];
            int count_col = table.Columns.Count;

            for (int c = 0; c < count_col; c++)
            {
                var value = row.Field<object>(table.Columns[c]);
                if (null == value)
                {
                    result.Add(0);
                }
                else
                {
                    try
                    {
                        result.Add(int.Parse(value.ToString()));
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("解析错误: " + table.TableName);
                        throw;
                    }
                }
            }

            return result;
        }

        static List<string> GetFieldType(DataTable table, int r)
        {
            List<string> result = new List<string>();

            DataRow row = table.Rows[r];
            int count_col = table.Columns.Count;

            for (int c = 0; c < count_col; c++)
            {
                var value = row.Field<object>(table.Columns[c]);
                if (null == value)
                {
                    result.Add("");
                }
                else
                {
                    try
                    {
                        result.Add(value.ToString());
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("解析错误: " + table.TableName);
                        throw;
                    }
                }
            }

            return result;
        }

        static List<string> GetFieldName(DataTable table, int r)
        {
            List<string> result = new List<string>();

            DataRow row = table.Rows[r];
            int count_col = table.Columns.Count;

            for (int c = 0; c < count_col; c++)
            {
                var value = row.Field<object>(table.Columns[c]);
                if (null == value)
                {
                    result.Add("");
                }
                else
                {
                    try
                    {
                        result.Add(value.ToString());
                    }
                    catch (System.Exception)
                    {
                        Console.WriteLine("解析错误: " + table.TableName);
                        throw;
                    }
                }
            }

            return result;
        }

        static void PrintTable(DataTable table)
        {
            int count_row = table.Rows.Count;
            int count_col = table.Columns.Count;

            Console.WriteLine("Row: " + count_row);
            Console.WriteLine("Column: " + count_col);

            for (int r = 0; r < count_row; r++)
            {
                for (int c = 0; c < count_col; c++)
                {
                    var row = table.Rows[r];
                    var value = row.Field<object>(table.Columns[c]);
                    if (null == value)
                    {
                        Console.Write("{0, -16}", "null");
                    }
                    else
                    {
                        Console.Write("{0, -16}", value.ToString());
                    }
                }
                Console.WriteLine("");
            }
        }
    }
}
