namespace Mori.Patterns.StructuralPatterns.Bridge.Example
{
    public abstract class Programmer
    {
        private ILanguage language;
        
        public ILanguage Language
        {
            set => language = value;
        }

        protected Programmer (ILanguage lang)
        {
            language = lang;
        }
        
        public virtual void DoWork()
        {
            language.Build();
            language.Execute();
        }
        
        public abstract void EarnMoney();
    }
}