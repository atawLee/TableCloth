﻿using System;
using System.Runtime.CompilerServices;
using TableCloth.Resources;

namespace TableCloth
{
    public sealed class TableClothAppException : ApplicationException
    {
        public static TableClothAppException Issue(
            string
#if !NETFX
?
#endif
            reason = "",
            [CallerFilePath] string file = "", [CallerMemberName] string member = "", [CallerLineNumber] int line = 0,
            Exception
#if !NETFX
?
#endif
            innerException = default)
        {
            return new TableClothAppException(reason, file, member, line, innerException);
        }

        public static void Throw(
            string
#if !NETFX
?
#endif
            reason = "",
            [CallerFilePath] string file = "", [CallerMemberName] string member = "", [CallerLineNumber] int line = 0,
            Exception
#if !NETFX
?
#endif
            innerException = default)
        {
            throw new TableClothAppException(reason, file, member, line, innerException);
        }

        public TableClothAppException(string
#if !NETFX
?
#endif
            reason, string file, string member, int line,
            Exception
#if !NETFX
?
#endif
            innerException = default)
            : base((reason ?? "Unknown reason") + " (" + StringResources.Error_Unknown(file, member, line) + ")", innerException)
        {
            File = file ?? "(Unknown)";
            Member = member ?? "(Unknown)";
            Line = line;
        }

        public string File { get; private set; }

        public string Member { get; private set; }

        public int Line { get; private set; }
    }
}
