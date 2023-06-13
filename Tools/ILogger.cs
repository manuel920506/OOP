using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools {
    public interface ILogger {
        void LogError(string message);
        void LogInfo(string message);
        void LogWarning(string message);
    }

    public sealed class ConsoleLogger : ILogger {
        private static ConsoleLogger _instance = null; 
        private static object _protect = new object(); 

        public static ConsoleLogger GetInstance() {
            lock (_protect) {
                if (_instance == null) {
                    _instance = new ConsoleLogger();
                }
            }

            return _instance;
        }

        private ConsoleLogger() { 
            Console.WriteLine($"Sono entrato al costruttore privato");
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

    enum ErrorType {
        Info,
        Warning,
        Error
    }

    //Domande
    //Il costruttore privato si invoca ogni talvolta faccio ad esempio FileLogger.GetInstance() ???? Risposta: no
    //perchè non posso avere come statici i membri implementati da una interfaccia: non si può.
    public sealed class FileLogger : ILogger {
        private static FileLogger _instance = null;
        private static string _path;
        private static object _protect = new object();
        private string keyPath = "PathLog";

        public static FileLogger GetInstance() {
            lock (_protect) {
                if (_instance == null) {
                    _instance = new FileLogger();
                }
            }

            return _instance;
        }

        private FileLogger() {
            _path = ConfigurationManager.AppSettings[keyPath] ?? String.Empty;
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
                streamWriter.WriteLine(DateTime.Now + " "+ errorType.ToString() + ": " + message);
            }
        }
    }
}
