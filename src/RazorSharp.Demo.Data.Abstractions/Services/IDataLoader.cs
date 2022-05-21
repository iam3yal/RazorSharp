namespace RazorSharp.Demo.Data.Abstractions.Services;

using System.Threading.Tasks;

public interface IDataLoader
{
    Task LoadDataAsync();
}