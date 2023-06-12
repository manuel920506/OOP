//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConsoleAppDependencyInjection {
//    public interface ILogger {
//        void LogError(string message);
//        void LogInfo(string message);
//        void LogWarning(string message);
//    }

//    public class ConsoleLogger : ILogger {
//        public void LogError(string message) {
//            Log(message, ErrorType.Error, ConsoleColor.Red);
//        }

//        public void LogInfo(string message) {
//            Log(message, ErrorType.Info, ConsoleColor.Green);
//        }
        
//        public void LogWarning(string message) {
//            Log(message, ErrorType.Warning, ConsoleColor.Yellow);
//        }

//        private void Log(string message, ErrorType errorType, ConsoleColor color) {
//            Console.ForegroundColor = color;
//            Console.WriteLine(errorType.ToString() + ": " + message); 
//        }
//    }

//    enum ErrorType {
//        Info,
//        Warning,
//        Error
//    }
//    public class FileLogger : ILogger {
//        private readonly string _path;

//        public FileLogger(string path) {
//            _path = path;
//        }

//        public void LogError(string message) {
//            Log(message, ErrorType.Error);
//        }

//        public void LogInfo(string message) {
//            Log(message, ErrorType.Info);
//        }

//        public void LogWarning(string message) {
//            Log(message, ErrorType.Warning);
//        }

//        private void Log(string message, ErrorType errorType) {
//            using (var streamWriter = new StreamWriter(_path, true)) {
//                streamWriter.WriteLine(errorType.ToString() + ": " + message);
//            }
//        }
//    }
//}
