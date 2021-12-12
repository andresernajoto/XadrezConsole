using System;

namespace XadrezConsole.Quadro.Exceptions {
    // herdado de Exception
    class TabuleiroException : Exception {
        // Exceção personalizada
        public TabuleiroException(string message) : base(message) { }
    }
}
