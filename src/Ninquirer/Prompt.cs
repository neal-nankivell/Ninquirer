#nullable enable
using Ninquirer.Internal;

namespace Ninquirer
{
    public static class Prompt
    {
        public static bool Confirm(string message) => new Confirm().Ask(message);
    }
}
