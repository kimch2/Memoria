﻿using System;
using System.IO;

namespace Memoria.Compiler
{
    internal static class Program
    {
        private const String DefaultReferencesPath64 = "../../../x64/FF9_Data/Managed/";
        private const String DefaultReferencesPath86 = "../../../x86/FF9_Data/Managed/";
        private const String DefaultSourcesPath = "../Sources/";
        private const String DefaultOutputPath = "../";
        private const String DefaultOutputName = "Memoria.Scripts.dll";

        internal static void Main(String[] args)
        {
            try
            {
                Compile();
                Console.WriteLine("Success!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Fail!");
            }

            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }

        private static void Compile()
        {
            String referencesDirectoryPath;
            if (Directory.Exists(DefaultReferencesPath64))
                referencesDirectoryPath = Path.GetFullPath(DefaultReferencesPath64);
            else if (Directory.Exists(DefaultReferencesPath86))
                referencesDirectoryPath = Path.GetFullPath(DefaultReferencesPath86);
            else
                throw new DirectoryNotFoundException("Cannot find the directory \"FF9_Data/Managed/\"");

            String sourcesDirectoryPath = Path.GetFullPath(DefaultSourcesPath);
            if (!Directory.Exists(sourcesDirectoryPath))
                throw new DirectoryNotFoundException("Directory not found: " + sourcesDirectoryPath);

            String outputDirectoryPath = Path.GetFullPath(DefaultOutputPath);
            if (!Directory.Exists(outputDirectoryPath))
                throw new DirectoryNotFoundException("Directory not found: " + outputDirectoryPath);

            String outputFileName = DefaultOutputName;
            if (String.IsNullOrWhiteSpace(outputFileName))
                throw new InvalidDataException("You must specify a name for output file.");
            
            Compiler compiler = new Compiler(referencesDirectoryPath, sourcesDirectoryPath, outputDirectoryPath, outputFileName);
            compiler.Compile();
        }
    }
}