using Svg;
using System;
using System.IO;
using System.Text.RegularExpressions;
using WatermarkRemoveStaruml;

namespace svgWatermarkRemoveStaruml
{
    class Program
    {
        enum ReturnType
        {
            Complite = 0,
            FileNotFound = -1,
            AccessError = -2,
            EtcError = -3,
            DoNotProcess = 1,
        }

        static void Save(FileInfo inputPath, string outputPath, float? width)
        {
            var svgDocument = SvgDocument.Open(inputPath.FullName);

            if (svgDocument == null)
            {
                Console.WriteLine($"Error: Failed to load input file: {inputPath.FullName}");
                Console.ReadKey();
                return;
            }

            //if (width.HasValue)
            //{
            //    svgDocument.Width = width.Value;
            //    svgDocument.Height = width.Value;
            //}

            using (var bitmap = svgDocument.Draw((int)width.Value, 0))
            {
                bitmap?.Save(outputPath);
            }
        }

        static int WaterMarkRemove(string aFileName)
        {
            int ret = (int)ReturnType.Complite;

            if (!File.Exists(aFileName))
            {
                ret = (int)ReturnType.FileNotFound;
                return ret;
            }

            try
            {
                using (StringWriter sw = new StringWriter())
                {
                    using (StreamReader ReadStream = File.OpenText(aFileName))
                    {
                        string temp;
                        var pattern = "<text fill=\"#\\w+\" stroke=\"\\w+\" font-family=\"\\w+\" font-size=\"\\w+\" font-style=\"\\w+\" font-weight=\"\\w+\" text-decoration=\"\\w+\" x=\"\\w+\" y=\"\\w+\">UNREGISTERED</text>";

                        while ((temp = ReadStream.ReadLine()) != null)
                        {
                            var replaced = Regex.Replace(temp, pattern, "");
                            sw.WriteLine(replaced);
                        }
                    }
                    sw.Flush();

                    using (StreamWriter stream = new StreamWriter(aFileName))
                    {
                        stream.Write(sw.GetStringBuilder().ToString());
                        stream.Flush();
                    }
                }

                var file = new FileInfo(aFileName);
                var outputPath = string.Empty;
                outputPath = Path.ChangeExtension(file.FullName, ".png");
                Save(file, outputPath, 2853);

            }
            catch (Exception ex)
            {
                ret = (int)ReturnType.EtcError;
                Console.WriteLine(ex.Message);
            }

            return ret;
        }

        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                if (args[0].ToLower().IndexOf(".svg") != -1)
                {
                    //Console.WriteLine($"{args[0]}");
                    WaterMarkRemove(args[0]);
                }
            }
        }
    }
}
