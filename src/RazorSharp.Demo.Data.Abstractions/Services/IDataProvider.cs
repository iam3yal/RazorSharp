namespace RazorSharp.Demo.Data.Abstractions.Services;

public interface IDataProvider<out T>
{
    T GetData();
}