using MauiBase.Constants;
using MauiBase.Data.Repositories.AppUserSettings;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace MauiBase.APIWrappers
{
    public class BaseApiWrapper : IBaseApiWrapper
    {
        protected readonly HttpClient _client;
        private readonly IAppUserSettingRepository _appUserSettingRepository;
        public BaseApiWrapper(IAppUserSettingRepository appUserSettingRepository)
        {
            _appUserSettingRepository = appUserSettingRepository;
            _client = new HttpClient
            {
                BaseAddress = new Uri(Constants.AppConstant.ApiUrl),
                Timeout = TimeSpan.FromSeconds(30)
            };
        }
        private async Task SetBearerToken()
        {
            if (_client.DefaultRequestHeaders.Contains("Authorization"))
                _client.DefaultRequestHeaders.Remove("Authorization");
            var token = await _appUserSettingRepository.GetAsync(AppSettingNames.AuthorizationToken);

            if (token == null)
            {
                return;
            }

            _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token);
        }

        private void RemoveBearerToken()
        {
            _client.DefaultRequestHeaders.Authorization = null;
        }

        private async Task PrepareClient(bool haveBearerToken)
        {
            if (haveBearerToken)
            {
                await SetBearerToken();
            }
            else
            {
                RemoveBearerToken();
            }
        }

        public void AddHeader(string name, string value)
        {
            if (_client.DefaultRequestHeaders.Contains(name))
                _client.DefaultRequestHeaders.Remove(name);

            _client.DefaultRequestHeaders.Add(name, value);
        }

        public void RemoveHeader(string name)
        {
            if (_client.DefaultRequestHeaders.Contains(name))
                _client.DefaultRequestHeaders.Remove(name);
        }
        #region GET

        public async Task<T?> GetAsync<T>(string url, bool haveBearerToken)
        {
            await PrepareClient(haveBearerToken);
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        #endregion

        #region POST

        public async Task<TResponse?> PostAsync<TRequest, TResponse>(string url, TRequest data, bool haveBearerToken)
        {
            await PrepareClient(haveBearerToken);
            var response = await _client.PostAsJsonAsync(url, data);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<TResponse>();
        }

        public async Task PostAsync<TRequest>(string url, TRequest data, bool haveBearerToken)
        {
            await PrepareClient(haveBearerToken);
            var response = await _client.PostAsJsonAsync(url, data);
            response.EnsureSuccessStatusCode();
        }

        #endregion

        #region PUT

        public async Task<TResponse?> PutAsync<TRequest, TResponse>(string url, TRequest data, bool haveBearerToken)
        {
            await PrepareClient(haveBearerToken);
            var response = await _client.PutAsJsonAsync(url, data);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<TResponse>();
        }

        public async Task PutAsync<TRequest>(string url, TRequest data, bool haveBearerToken)
        {
            await PrepareClient(haveBearerToken);
            var response = await _client.PutAsJsonAsync(url, data);
            response.EnsureSuccessStatusCode();
        }

        #endregion

        #region DELETE
        public async Task DeleteAsync(string url, bool haveBearerToken)
        {
            await PrepareClient(haveBearerToken);
            var response = await _client.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
        }
        #endregion
    }
}