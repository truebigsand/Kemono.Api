using Kemono.Api.Extensions;
using Kemono.Api.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Kemono.Api
{
    public class KemonoApi : IDisposable
    {
        private JsonStringEnumConverter<ServiceType> _serviceTypeConverter;
        private CookieContainer _cookieContainer;
        private HttpClient _httpClient;
        public KemonoApi()
        {
            _serviceTypeConverter = new JsonStringEnumConverter<ServiceType>();
            _cookieContainer = new CookieContainer();
            _httpClient = new HttpClient(new HttpClientHandler()
            {
                CookieContainer = _cookieContainer
            })
            {
                BaseAddress = new Uri("https://kemono.su/api/v1/"),
            };
        }
        /// <summary>
        /// List all creators with details.
        /// </summary>
        /// <returns>List of all creators with details.</returns>
        public async Task<IEnumerable<Creator>> GetAllCreatorsAsync()
            => await _httpClient.GetJsonAsync<IEnumerable<Creator>>("creators.txt");
        /// <summary>
        /// List recent posts
        /// </summary>
        /// <param name="query">Search query</param>
        /// <param name="offset">Result offset, stepping of 50 is enforced</param>
        /// <returns>List of recently imported posts</returns>
        public async Task<IEnumerable<Post>> GetRecentPostsAsync(string query = "", int offset = 0)
            => await _httpClient.GetJsonAsync<IEnumerable<Post>>($"posts?q={query}&o={offset}");
        /// <summary>
        /// Get a list of creator's posts
        /// </summary>
        /// <param name="service">The service where the post is located</param>
        /// <param name="creatorId">The the creator's id</param>
        /// <param name="query">Search query</param>
        /// <param name="offset">Result offset, stepping of 50 is enforced</param>
        /// <returns>List of creator's posts</returns>
        public async Task<IEnumerable<Post>> GetCreatorPostsAsync(ServiceType service, string creatorId, string query = "", int offset = 0)
            => await _httpClient.GetJsonAsync<IEnumerable<Post>>($"{service.ToString().ToLower()}/user/{creatorId}?q={query}&o={offset}");
        /// <summary>
        /// Get creator's posts
        /// </summary>
        /// <param name="creator">The instance of the creator</param>
        /// <param name="query">Search query</param>
        /// <param name="offset">Result offset, stepping of 50 is enforced</param>
        /// <returns>List of creator's posts</returns>
        public async Task<IEnumerable<Post>> GetCreatorPostsAsync(Creator creator, string query = "", int offset = 0)
            => await _httpClient.GetJsonAsync<IEnumerable<Post>>($"{creator.Service.ToString().ToLower()}/user/{creator.Id}?q={query}&o={offset}");
        /// <summary>
        /// Get creator's announcements
        /// </summary>
        /// <param name="service">The service where the post is located</param>
        /// <param name="creatorId">The creator's id</param>
        /// <returns>List of creator's announcements</returns>
        public async Task<IEnumerable<Announcement>> GetCreatorAnnouncementsAsync(ServiceType service, string creatorId)
            => await _httpClient.GetJsonAsync<IEnumerable<Announcement>>($"{service.ToString().ToLower()}/user/{creatorId}/announcements");
        /// <summary>
        /// Get creator's announcements
        /// </summary>
        /// <param name="creator">The instance of the creator</param>
        /// <returns></returns>
        public async Task<IEnumerable<Announcement>> GetCreatorAnnouncementsAsync(Creator creator)
            => await _httpClient.GetJsonAsync<IEnumerable<Announcement>>($"{creator.Service.ToString().ToLower()}/user/{creator.Id}/announcements");
        /// <summary>
        /// Get fancards by creator, fanbox only
        /// </summary>
        /// <param name="creatorId">The creator's id</param>
        /// <returns>List of creator's fancards</returns>
        public async Task<IEnumerable<Fancard>> GetCreatorFancardsAsync(string creatorId)
            => await _httpClient.GetJsonAsync<IEnumerable<Fancard>>($"fanbox/user/{creatorId}/announcements");
        /// <summary>
        /// Get fancards by creator, fanbox only
        /// </summary>
        /// <param name="creator">The instacne of the creator</param>
        /// <returns>List of creator's fancards</returns>
        public async Task<IEnumerable<Fancard>> GetCreatorFancardsAsync(Creator creator)
            => await _httpClient.GetJsonAsync<IEnumerable<Fancard>>($"fanbox/user/{creator.Id}/announcements");
        /// <summary>
        /// Get a specific post
        /// </summary>
        /// <param name="service">The service where the post is located</param>
        /// <param name="creatorId">The the creator's id</param>
        /// <param name="postId">The post's id</param>
        /// <returns>The instance of the post</returns>
        public async Task<Post> GetCreatorPostAsync(ServiceType service, string creatorId, string postId)
            => await _httpClient.GetJsonAsync<Post>($"{service.ToString().ToLower()}/user/{creatorId}/post/{postId}");
        /// <summary>
        /// Get a specific post
        /// </summary>
        /// <param name="creator">The instance of the creator</param>
        /// <param name="postId">The post's id</param>
        /// <returns>The instance of the post</returns>
        public async Task<Post> GetCreatorPostAsync(Creator creator, string postId)
            => await _httpClient.GetJsonAsync<Post>($"{creator.Service.ToString().ToLower()}/user/{creator.Id}/post/{postId}");
        /// <summary>
        /// List a post's revisions
        /// </summary>
        /// <param name="service">The service where the post is located</param>
        /// <param name="creatorId">The the creator's id</param>
        /// <param name="postId">The post's id</param>
        /// <returns>List of the post's revisions</returns>
        public async Task<IEnumerable<Revision>> GetCreatorPostRevisionsAsync(ServiceType service, string creatorId, string postId)
            => await _httpClient.GetJsonAsync<IEnumerable<Revision>>($"{service.ToString().ToLower()}/user/{creatorId}/post/{postId}/revisions");
        /// <summary>
        /// List a post's revisions
        /// </summary>
        /// <param name="creator">The instance of the creator</param>
        /// <param name="postId">The post's id</param>
        /// <returns>List of the post's revisions</returns>
        public async Task<IEnumerable<Revision>> GetCreatorPostRevisionsAsync(Creator creator, string postId)
            => await _httpClient.GetJsonAsync<IEnumerable<Revision>>($"{creator.Service.ToString().ToLower()}/user/{creator.Id}/post/{postId}/revisions");
        /// <summary>
        /// List a post's revisions
        /// </summary>
        /// <param name="post">The instance of the post</param>
        /// <returns>List of the post's revisions</returns>
        public async Task<IEnumerable<Revision>> GetCreatorPostRevisionsAsync(Post post)
        {
            var allCreators = await GetAllCreatorsAsync();
            var creator = allCreators.Where(c => c.Name == post.User).Single();
            return await _httpClient.GetJsonAsync<IEnumerable<Revision>>($"{creator.Service.ToString().ToLower()}/user/{creator.Id}/post/{post.Id}/revisions");
        }
        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }

    [Serializable]
    public class UnAuthorizedException : Exception
    {
        public UnAuthorizedException() { }
        public UnAuthorizedException(string message) : base(message) { }
        public UnAuthorizedException(string message, Exception inner) : base(message, inner) { }
    }
}