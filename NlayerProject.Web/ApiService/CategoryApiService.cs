using Newtonsoft.Json;
using NLayerProject.Web.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NlayerProject.Web.ApiService
{
    public class CategoryApiService
    {
        private readonly HttpClient _client;
        public CategoryApiService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            IEnumerable<CategoryDto> categoryDtos;
            var response = await _client.GetAsync("categories");

            if (response.IsSuccessStatusCode)
                categoryDtos = JsonConvert.DeserializeObject<IEnumerable<CategoryDto>>(await response.Content.ReadAsStringAsync());
            else
                categoryDtos = null;

            return categoryDtos;
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {

            var response = await _client.GetAsync($"categories/{id}");

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<CategoryDto>(await response.Content.ReadAsStringAsync());
            else
                return null;
        }

        public async Task<CategoryDto> AddAsync(CategoryDto categoryDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(categoryDto), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(_client.BaseAddress + "categories", stringContent);

            if (response.IsSuccessStatusCode)
            {
                categoryDto = JsonConvert.DeserializeObject<CategoryDto>(await response.Content.ReadAsStringAsync());
                return categoryDto;
            }
            else
                return null;

        }

        public async Task<bool> Update(CategoryDto categoryDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(categoryDto), Encoding.UTF8, "application/json");

            var response = await _client.PutAsync("categories", stringContent);

            if (response.IsSuccessStatusCode)
                return true;
            else
                return false;
        }

        public async Task<bool> Remove(int id)
        {
            var response = await _client.DeleteAsync($"categories/{id}");

            if (response.IsSuccessStatusCode)
                return true;
            else
                return false;
        }
    }
}
