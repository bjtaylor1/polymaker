using System;
using System.IO;
using System.Threading.Tasks;

namespace polymaker
{
    class Program
    {
        static async Task Main(string[] args)
        {
            if(args.Length != 3)
            {
                await Console.Out.WriteLineAsync("Usage: polymaker [name] [from] [to]");
            };
            var name = args[0];
            var from = double.Parse(args[1]);
            var to = double.Parse(args[2]);            
            await using var sw = new StreamWriter($"{name}.poly");
            await sw.WriteLineAsync($"{name}");
            if(to > from)
            {
                await WritePolySection("entirety", sw, from, to);
            }
            else
            {
                await WritePolySection("area1", sw, -180, to);
                await WritePolySection("area2", sw, from, 180);
            }
            await sw.WriteLineAsync($"END");
            await sw.FlushAsync();
        }

        static async Task WritePolySection(string sectionName, StreamWriter sw, double from, double to)
        {
            if(from >= to)
            {
                throw new ArgumentException("To must be greater than from");
            }

            await sw.WriteLineAsync($"{sectionName}");
            await sw.WriteLineAsync($"  {from} 90");
            await sw.WriteLineAsync($"  {from} -90");
            await sw.WriteLineAsync($"  {to} -90");
            await sw.WriteLineAsync($"  {to} 90");
            await sw.WriteLineAsync($"  {from} 90");
            await sw.WriteLineAsync($"END");
        }
    }
}
