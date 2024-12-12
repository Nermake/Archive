using Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example2.Message;

namespace Mori.Patterns.PatternsOfBehavior.ChainOfResponsibility.Example2.Processor
{
    public class GenericQuestProcessor<TMessage> : QuestProcessorBase where TMessage : QuestMessageBase
    {
        
    }
}