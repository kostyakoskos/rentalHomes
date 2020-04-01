﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace TrainingProject.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
               .MinimumLevel.Debug()
               .WriteTo.Console()
               .WriteTo.File(@"C:\\Education\\asp\\RentalHomes\\log.txt")//сделать так чтобы лог писался в папку проекта(application data) appsetting
               .CreateLogger();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(builder => builder.ClearProviders()
                    .AddSerilog().AddDebug().AddConsole())
                .ConfigureWebHostDefaults(webBuilder => {

                    webBuilder.UseStartup<Startup>();
                });
    }
}