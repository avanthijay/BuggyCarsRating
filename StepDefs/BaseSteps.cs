using TechTalk.SpecFlow;
using BuggyCarsDemo.Modal;

namespace BuggyCarsDemo.StepDefs
{
    [Binding]
    public class BaseSteps
    {
        protected ContextObject Context;

        public BaseSteps(ContextObject context)
        {
            Context = context;
        }
    }
}
