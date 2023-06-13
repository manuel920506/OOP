using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Factory {
    // Creator
    public abstract class LoggerFactory
    { 
        public abstract ILogger GetLogger();
    }

    // Concrete Creater
    public class ConsoleLoggerFactory : LoggerFactory
    {
        public ConsoleLoggerFactory()
        { 
        }

        public override ILogger GetLogger() {
            return new ConsoleLogger();
        } 
    }

    public class FileLoggerFactory : LoggerFactory
    {
        private string _path;
        private string keyPath = "PathLog";

        public FileLoggerFactory(string path) {
            _path = path;
        }

        public override ILogger GetLogger() {
            return new FileLogger(_path);
        }
    }

    // Concrete Product
    public class ConsoleLogger : ILogger { 
        public ConsoleLogger()
        { 
        }

        public void LogError(string message) {
            Log(message, ErrorType.Error, ConsoleColor.Red);
        }

        public void LogInfo(string message) {
            Log(message, ErrorType.Info, ConsoleColor.Green);
        }

        public void LogWarning(string message) {
            Log(message, ErrorType.Warning, ConsoleColor.Yellow);
        }

        private void Log(string message, ErrorType errorType, ConsoleColor color) {
            Console.ForegroundColor = color;
            Console.WriteLine(errorType.ToString() + ": " + message);
        }
    }

    // Concrete Product
    public class FileLogger : ILogger {
        private static string _path;
        public FileLogger(string path) { 
            _path = path;
        }

        public void LogError(string message) {
            Log(message, ErrorType.Error);
        }

        public void LogInfo(string message) {
            Log(message, ErrorType.Info);
        }

        public void LogWarning(string message) {
            Log(message, ErrorType.Warning);
        }

        private static void Log(string message, ErrorType errorType) {
            using (var streamWriter = new StreamWriter(_path, true)) {
                streamWriter.WriteLine(DateTime.Now + " " + errorType.ToString() + ": " + message);
            }
        }
    }



    // Product
    public interface ILogger {
        void LogError(string message);
        void LogInfo(string message);
        void LogWarning(string message);
    }
}
