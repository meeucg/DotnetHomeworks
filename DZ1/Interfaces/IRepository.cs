namespace DZ1.Interfaces;

public interface IRepository<in TKey, TResult>
{
    Task<TResult?> Get(TKey key);
    Task<TResult> Add(TResult entity);
    Task<bool> Remove(TKey key);
    Task<TResult?> Update(TKey key, TResult entity);
    Task<bool> Exists(TKey key);
}