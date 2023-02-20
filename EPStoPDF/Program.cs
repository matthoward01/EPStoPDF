using Ghostscript.NET;
using Ghostscript.NET.Processor;
using System;
using System.Collections.Generic;
using System.IO;

namespace EPStoPDF
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = @"C:\test.eps";
            EPStoPDF(file);
        }
        public static void EPStoPDF(string printFile)
        {
            GhostscriptVersionInfo gvi = new GhostscriptVersionInfo(new Version(0, 0, 0), System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "References", "gsdll64.dll"), string.Empty, GhostscriptLicense.GPL);
            using (GhostscriptProcessor processor = new GhostscriptProcessor(gvi))
            {
                List<string> switches = new List<string>();
                //switches.Add("-dPrinted");
                //switches.Add("-dBATCH");
                //switches.Add("-dNOPAUSE");
                switches.Add("-dNOSAFER");
                /*if (tabloid)
                {
                    switches.Add("-g792x1224");
                }
                if (fit)
                {
                    switches.Add("-dPDFFitPage");

                }*/
                //switches.Add("-dNumCopies=1");
                switches.Add("-sDEVICE=pdfwrite");
                switches.Add("-AutoRotatePages=/None");
                //switches.Add("-ProduceDSC=false");
                switches.Add("-dSetPageSize=false");
                switches.Add("-dEPSCrop=true");
                switches.Add("-dCompressPages=false");
                switches.Add("-dGrayImageResolution=300");
                switches.Add("-dPreserveSeparation=true");
                //switches.Add("-dEmbedAllFonts=true");
                //switches.Add("-dOptimize=false");
                //switches.Add("-dDownsampleColorImages=false");
                //switches.Add("-dDownsampleGrayImages=false");
                //switches.Add("-dDownsampleMonoImages=false");
                //switches.Add(Convert.ToString("-sOutputFile=%printer%") + Settings.Default.Printer);
                
                switches.Add("-o");
                switches.Add(Path.Combine(Path.GetDirectoryName(printFile), Path.GetFileNameWithoutExtension(printFile) + ".pdf"));
                switches.Add(printFile);
                processor.StartProcessing(switches.ToArray(), null);
            }
        }
    }
}
