using System;
using System.Collections.Generic;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

// ST10067040
namespace MunicipalServicesApp
{
    public class GraphVisualizer<T>
    {
        private readonly Graph<T> graph;

        public GraphVisualizer(Graph<T> graph)
        {
            this.graph = graph;
        }

        public string ExportToDot(Func<T, string> nodeLabelGenerator)
        {
            var dotBuilder = new StringBuilder();
            dotBuilder.AppendLine("digraph G {");

            foreach (var node in graph.GetNodes())
            {
                dotBuilder.AppendLine($"\"{nodeLabelGenerator(node)}\";");
                foreach (var edge in graph.GetEdges(node))
                {
                    dotBuilder.AppendLine($"\"{nodeLabelGenerator(node)}\" -> \"{nodeLabelGenerator(edge)}\";");
                }
            }

            dotBuilder.AppendLine("}");
            return dotBuilder.ToString();
        }


    }

    public class GraphRenderer
    {
        public static Image RenderGraph(string dotGraph)
        {
            string dotFilePath = "graph.dot";
            string outputFilePath = $"graph_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.png";
            string dotExePath = @"C:\Program Files\Graphviz\bin\dot.exe"; 

            // Write the DOT graph to a file
            File.WriteAllText(dotFilePath, dotGraph);

            var startInfo = new ProcessStartInfo
            {
                FileName = dotExePath,
                Arguments = $"-Tpng \"{dotFilePath}\" -o \"{outputFilePath}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            try
            {
                using (var process = Process.Start(startInfo))
                {
                    process.WaitForExit();

                    if (process.ExitCode != 0)
                    {
                        string error = process.StandardError.ReadToEnd();
                        throw new Exception($"Graphviz dot execution failed: {error}");
                    }

                    // Return the generated image
                    return Image.FromFile(outputFilePath);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error generating graph: {ex.Message}", ex);
            }
        }
    }
}