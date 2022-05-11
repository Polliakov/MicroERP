namespace DataBase.Contexts
{
    public abstract class MicroERPContextSingleton
    {
        public static readonly MicroERPContext Instanse = new MicroERPContext();
    }
}
