using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace polymaker
{
    class Program
    {
        static void Main(string[] args)
        {
            Parallel.For(-180, 180, async (i, ps) => 
            {
                await using var sw = new StreamWriter($"degree{i}.poly");
                await sw.WriteLineAsync($"degree{i}");
                await sw.WriteLineAsync($"standard");
                await sw.WriteLineAsync($"  {i} 90");
                await sw.WriteLineAsync($"  {i} -90");
                await sw.WriteLineAsync($"  {i+1} -90");
                await sw.WriteLineAsync($"  {i+1} 90");
                await sw.WriteLineAsync($"  {i} 90");
                await sw.WriteLineAsync($"END");
                await sw.WriteLineAsync($"END");
            });
        }
    }
}
