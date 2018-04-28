using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Extensions
{
    public static class ExceptionExtension
    {
        public static string ToStringAll(this Exception ex)
        {
            Exception inner = ex;
            StringBuilder sb = new StringBuilder(inner.Message + ". ");
            while (inner.InnerException != null)
            {
                inner = inner.InnerException;
                sb.AppendLine(inner.Message + ". ");
            }

            return sb.ToString();
        }
    }
}
