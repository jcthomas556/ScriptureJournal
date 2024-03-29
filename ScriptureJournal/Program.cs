﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ScriptureJournal.Models;
using System;
using Microsoft.EntityFrameworkCore;

namespace ScriptureJournal
{
   public class Program
   {
      public static void Main(string[] args)
      {
         var host = CreateWebHostBuilder(args).Build();

         using (var scope = host.Services.CreateScope())
         {
            var services = scope.ServiceProvider;

            try
            {// this try is failing 
               var context = services.
                   GetRequiredService<ScriptureJournalContext>();
               context.Database.Migrate();
               SeedData.Initialize(services);//fails here
            }
            catch (Exception ex)
            {
               var logger = services.GetRequiredService<ILogger<Program>>();
               logger.LogError(ex, "An error occurred seeding the DB.");
            }
         }

         host.Run();
      }

      public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
          WebHost.CreateDefaultBuilder(args)
              .UseStartup<Startup>();
   }
}