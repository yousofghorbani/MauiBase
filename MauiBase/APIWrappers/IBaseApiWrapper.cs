namespace MauiBase.APIWrappers
{
    public interface IBaseApiWrapper
    {
        Task<T?> GetAsync<T>(string url, bool haveBearerToken);
        Task<TResponse?> PostAsync<TRequest, TResponse>(string url, TRequest data, bool haveBearerToken);
        Task PostAsync<TRequest>(string url, TRequest data, bool haveBearerToken);
        Task<TResponse?> PutAsync<TRequest, TResponse>(string url, TRequest data, bool haveBearerToken);
        Task PutAsync<TRequest>(string url, TRequest data, bool haveBearerToken);
        Task DeleteAsync(string url, bool haveBearerToken);
        void AddHeader(string name, string value);
        void RemoveHeader(string name);

    }
}