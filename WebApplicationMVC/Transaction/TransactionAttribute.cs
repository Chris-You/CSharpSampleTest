using System;

namespace WebApplicationMVC.Transaction
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class TransactionAttribute : Attribute
    {
    }
}