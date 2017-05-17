using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Es.Logging
{
    internal class OutPutQueue : IDisposable
    {
        private const int _maxQueuedMessages = 1024;

        private readonly BlockingCollection<LogMessage> _messageQueue = new BlockingCollection<LogMessage>(_maxQueuedMessages);

        private readonly Task _outputTask;

        public IConsole Console;

        public OutPutQueue()
        {
            _outputTask = Task.Factory.StartNew(
               ProcessQueue,
               this,
               TaskCreationOptions.LongRunning);
        }

        internal virtual void EnqueueMessage(LogMessage message)
        {
            if (!_messageQueue.IsAddingCompleted)
            {
                try
                {
                    _messageQueue.Add(message);
                    return;
                }
                catch (InvalidOperationException) { }
            }

            WriteMessage(message);
        }

        internal virtual void WriteMessage(LogMessage message)
        {
            Console.WriteLine(message.Message, message.Background, message.Foreground);
            Console.Flush();
        }

        private void ProcessQueue()
        {
            foreach (var message in _messageQueue.GetConsumingEnumerable())
            {
                WriteMessage(message);
            }
        }

        private static void ProcessQueue(object state)
        {
            var consoleLogger = (OutPutQueue)state;
            consoleLogger.ProcessQueue();
        }

        public void Dispose()
        {
            _messageQueue.CompleteAdding();

            try
            {
                _outputTask.Wait(1500);
            }
            catch
            {
            }
        }
    }

    internal class LogMessage
    {
        public ConsoleColor? Background;
        public ConsoleColor? Foreground;
        public string Message;
    }
}