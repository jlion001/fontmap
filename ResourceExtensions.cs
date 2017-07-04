    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    using System.Reflection;

    namespace jFont2
{
        static class ResourceExtensions
        {
            public static string GetCurrentNamespace()
            {
                string namespacename = Assembly.GetExecutingAssembly().ToString();

                return namespacename.Substring(0, namespacename.IndexOf(","));
            }

            public static string GetResourceTextFile(string filename)
            {
                string sResult = "";

                string resourcename = GetCurrentNamespace() + "." + filename;

                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourcename))
                {
                    //Read the stream 
                    using (StreamReader sr = new StreamReader(stream))
                    {
                        sResult = sr.ReadToEnd();
                    }

                }

                return sResult;
            }
        }
    }