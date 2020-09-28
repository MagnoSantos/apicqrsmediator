namespace webapicqrsmediator.Domain.Interfaces.Converters
{
    public interface IConversor<TEntrada, TSaida> 
        where TEntrada: class
        where TSaida : class
    {
        TSaida Convert(TEntrada input);
    }
}