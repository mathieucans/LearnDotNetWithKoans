using System;
using System.IO;

namespace LearnDotNet.utils
{
    public class ConsoleCapture : IDisposable
    {
        private StringWriter _stringWriter;
        private TextWriter _outToRestore;

        public ConsoleCapture()
        {
            _stringWriter = new StringWriter();
            _outToRestore = Console.Out;
            Console.SetOut(_stringWriter);
        }
        public void Dispose()
        {
            Console.SetOut(_outToRestore);
        }
    }
}