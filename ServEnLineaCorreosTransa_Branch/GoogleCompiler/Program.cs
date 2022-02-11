using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using Yahoo.Yui.Compressor;

namespace GoogleCompiler
{
    class Program
    {
        static void Main(string[] args)
        {
            ConvertFiles(".css");
            ConvertFiles(".js");
            
        }

        private static void ConvertFiles(string extension)
        {
            var fm = new FileManager();

            switch (extension)
            {
                case ".js":
                    Console.WriteLine("Javascript files");
                    var jsDocs = fm.GetDocuments(".js", @"..\..\..\CamaraComercio.Website", true);
                    foreach (var doc in jsDocs)
                    {
                        if (doc.Contains("-GC"))
                            continue;

                        #region Using Google Compiler (deprecated)
                        //NameValueCollection postValues = new NameValueCollection();
                        //string jsContent = File.ReadAllText(doc);
                        //postValues.Add("js_code", jsContent);
                        //if (doc.Contains("scripts/pages/"))
                        //    postValues.Add("compilation_level", "ADVANCED_OPTIMIZATIONS");
                        //else
                        //    postValues.Add("compilation_level", "SIMPLE_OPTIMIZATIONS");
                        //postValues.Add("output_format", "text");
                        //postValues.Add("output_info", "compiled_code");

                        //string response = "";
                        //HttpHelper.PerformQuery(postValues, out response);
                        #endregion

                        var jsFile = File.ReadAllText(doc);
                        var response = JavaScriptCompressor.Compress(jsFile);

                        if (response.Trim().Length > 0 && response != "\n")
                        {
                            var newDocPath = doc.Substring(0, doc.IndexOf(".js")) + "-GC" + ".js";
                            File.WriteAllText(newDocPath, response);
                            Console.WriteLine(String.Format("{0} >> {1}", doc, newDocPath));
                        }
                    }
                    Console.WriteLine("");
                    break;

                case ".css":
                    Console.WriteLine("CSS Files");
                    var cssDocs = fm.GetDocuments(".css", @"..\..\..\CamaraComercio.Website", true);
                    foreach (var doc in cssDocs)
                    {
                        if (doc.Contains("-GC"))
                            continue;

                        string cssFile = File.ReadAllText(doc);
                        string compressed = CssCompressor.Compress(cssFile);

                        if (compressed.Trim().Length > 0)
                        {
                            //string newDocPath = doc.Substring(0, doc.LastIndexOf("\\") + 1) + "compiled" +
                            //                    doc.Substring(doc.LastIndexOf("\\"));
                            string newDocPath = doc.Substring(0, doc.IndexOf(".css")) + "-GC" + ".css";
                            File.WriteAllText(newDocPath, compressed);
                            Console.WriteLine(String.Format("{0} >> {1}", doc, newDocPath));
                        }
                    }
                    Console.WriteLine("");
                    fm.Clear();
                    break;

                default:
                    break;
            }
            
        }

    }
}
