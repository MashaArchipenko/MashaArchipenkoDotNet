using Lab1.Interfaces;
using Lab1.Models;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;

namespace Lab1.BusinessLogic
{
    public class Processor
    {
        private readonly Logger logger;
        private readonly IReader reader;
        private readonly IWriter writer;

        public Processor(Logger logger, IReader reader, IWriter writer)
        {
            this.logger = logger;
            this.reader = reader;
            this.writer = writer;
        }
        public void Process(string[] commandLine)
        {
            IEnumerable<Student> students;
            try
            {
                students = reader.ReadFile(commandLine[(int)InputData.InputFilePath]);
            }
            catch(ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                logger.Error($"Invalid argument: {exception.Message}");
                return;
            }
            catch(IOException exception)
            {
                Console.WriteLine(exception.Message);
                logger.Error($"Input/output error: {exception.Message}");
                return;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                logger.Error($"Read error: {exception.Message}");
                return;
            }

            try
            {
                students = students.FindAverageMark();
                var allAverage = StudentHelper.FindAverageInAllSubjects(students);
                writer.WriteFile(commandLine[(int)InputData.OutputFilePath], students, allAverage);
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message);
                logger.Error($"Invalid argument: {exception.Message}");
                return;
            }
            catch (IOException exception)
            {
                Console.WriteLine(exception.Message);
                logger.Error($"Input/output error: {exception.Message}");
                return;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                logger.Error($"Write error: {exception.Message}");
                return;
            }
            Console.WriteLine("Successfully");
        }

    }
}
