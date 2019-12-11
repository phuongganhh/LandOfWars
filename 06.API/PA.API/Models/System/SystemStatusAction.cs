using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PA.API.Models.System
{
    public class SystemStatusAction : CommandBase<dynamic>
    {

        protected override Result<dynamic> ExecuteCore(ObjectContext context)
        {
            PerformanceCounter cpuCounter;
            PerformanceCounter ramCounter;

            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            var totalMemory = 0;

            int memsize = 0; // memsize in Megabyte
            PerformanceCounter PC = new PerformanceCounter();
            PC.CategoryName = "Process";
            PC.CounterName = "Working Set - Private";
            var p = Process.GetProcesses().Select(x =>
            {
                PC.InstanceName = x.ProcessName;
                memsize = Convert.ToInt32(PC.NextValue()) / (int)(1024);
                return new
                {
                    name = x.ProcessName,
                    memory = memsize
                };
            });
            PC.Close();
            PC.Dispose();
            return Success(new {
                ram = ramCounter.NextValue(),
                cpu = cpuCounter.NextValue(),
                process = p,
                total_ram = totalMemory / 1000.00
            });
        }
    }
}