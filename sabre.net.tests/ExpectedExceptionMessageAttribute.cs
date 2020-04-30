using System;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Commands;

namespace NUnit.Framework
{
    /// <summary>
    /// A simple ExpectedExceptionAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class ExpectedExceptionMessageAttribute : NUnitAttribute, IWrapTestMethod
    {
        private readonly string _expectedExceptionMessage;
        public ExpectedExceptionMessageAttribute(string expectedExceptionMessage)
        {
            _expectedExceptionMessage = expectedExceptionMessage;
        }

        public TestCommand Wrap(TestCommand command)
        {
            return new ExpectedExceptionCommand(command, _expectedExceptionMessage);
        }

        private class ExpectedExceptionCommand : DelegatingTestCommand
        {
            private readonly string _expectedExceptionMessage;

            public ExpectedExceptionCommand(TestCommand innerCommand, string expectedExceptionMessage)
                : base(innerCommand)
            {
                _expectedExceptionMessage = expectedExceptionMessage;
            }

            public override TestResult Execute(TestExecutionContext context)
            {
                string caughtExceptionMessage = "";
                try
                {
                    innerCommand.Execute(context);
                }
                catch (Exception ex)
                {
                    if (ex is NUnitException)
                        ex = ex.InnerException;
                    caughtExceptionMessage = ex.Message;
                }

                if (caughtExceptionMessage == _expectedExceptionMessage)
                    context.CurrentResult.SetResult(ResultState.Success);
                else if (caughtExceptionMessage != "")
                    context.CurrentResult.SetResult(ResultState.Failure,
                        string.Format("Expected {0} but got {1}", _expectedExceptionMessage, caughtExceptionMessage));
                else
                    context.CurrentResult.SetResult(ResultState.Failure,
                        string.Format("Expected {0} but no exception was thrown", _expectedExceptionMessage));
                return context.CurrentResult;
            }
        }
    }
}