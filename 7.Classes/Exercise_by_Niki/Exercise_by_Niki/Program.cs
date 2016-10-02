using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_by_Niki
{
    class Program
    {
        // 1. log to file
        // 2. print to file
        // 3. print other thing
         
        static void Main(string[] args)
        {
            Report report = new Report(new ConsoleLogger());
            report.LoadReport();
            var printer = new FilePrinter("print.txt");
            printer.Print(report);
            printer.Print(new DateTimeReport());
        }
    }

    class DateTimeReport : IContentProvider
    {
        public string ProvideContent()
        {
           var content = DateTime.Now.ToString();
            return content;
        }
    }

    interface IPrinter
    {
        void Print(IContentProvider contentProvider);
    }

    class ConsolePrinter : IPrinter
    {
        public void Print(IContentProvider contentProvider)
        {
            var content = contentProvider.ProvideContent();
            Console.WriteLine(content);
        }
    }

    class FilePrinter : IPrinter
    {
        private string fileName;

        public FilePrinter(string fileName)
        {
            this.fileName = fileName;
        }

        public void Print(IContentProvider contentProvider)
        {
            var content = contentProvider.ProvideContent();
            File.AppendAllText(fileName, content);
        Console.WriteLine(content);
        }
    }

    interface IContentProvider
    {
        string ProvideContent();
    }

    interface ILogger
    {
        void LogLine(string line);
    }

    public class ConsoleLogger : ILogger
    {
        public void LogLine(string line)
        {
            Console.WriteLine(line);
        }
    }

    public class FileLogger : ILogger
    {
        private string fileName;

        public FileLogger(string fileName)
        {
            this.fileName = fileName;
        }

        public void LogLine(string line)
        {
            File.AppendAllText(fileName, line + Environment.NewLine);
        }
    }

    class Report : IContentProvider
    {
        private ILogger logger;

        public Report(ILogger logger)
        {
            this.logger = logger;
        }

        public Report() 
            : this(new ConsoleLogger())
        {
        }

        public string Header { get; set; }

        public string Content { get; set; }

        public string Footer { get; set; }

        public void LoadReport()
        {
            // loads report
            this.Header = "header";
            this.Content = "content";
            this.Footer = "footer";
            this.logger.LogLine("report loaded");
        }

        //public void Print()
        //{
        //    // Printer, Com, Network ...
        //    this.logger.LogLine(this.Header);
        //    this.logger.LogLine(this.Content);
        //    this.logger.LogLine(this.Footer);
        //    this.logger.LogLine("data printed");
        //}

        public string ProvideContent()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(this.Header);
            stringBuilder.AppendLine(this.Content);
            stringBuilder.AppendLine(this.Footer);
            return stringBuilder.ToString();
        }
    }
}
