using System;
using System.Linq;

namespace WebApp.Helpers
{
    public static class ParamHelpers
    {
        public static object[] GetParams(params object[] arguments)
        {
            return arguments.Where (s => s != null).ToArray();
        }
    }
}