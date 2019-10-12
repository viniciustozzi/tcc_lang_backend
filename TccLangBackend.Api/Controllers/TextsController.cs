using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TccLangBackend.Api.Business.Feed;
using TccLangBackend.Api.Controllers.Requests;
using TccLangBackend.Core.Deck;
using TccLangBackend.Core.Text;
using Post = TccLangBackend.Api.Business.Feed.Post;

namespace TccLangBackend.Api.Controllers
{
    [Route("api/texts")]
    [ApiController]
    public class TextController : UtilControllerBase
    {
        private readonly TextBusiness _textBusiness;
        private readonly FeedBusiness _feedBusiness;

        public TextController(TextBusiness textBusiness, FeedBusiness feedBusiness)
        {
            _textBusiness = textBusiness;
            _feedBusiness = feedBusiness;
        }

        [HttpGet]
        public IEnumerable<SummaryText> GetTexts() => _textBusiness.GetAll();

        [HttpPost]
        public Task SaveText([FromBody] CreateTextRequest createTextRequest) =>
            _textBusiness.CreateAsync(new CreateText(createTextRequest.Words, createTextRequest.Title));

        [HttpGet("{textId}")]
        public Task<DetailedText> GetText(int textId) => _textBusiness.GetAsync(UserId, textId);

        [HttpPost("feed"), AllowAnonymous]
        public async Task<IEnumerable<Post>> Feed([FromQuery] string url)
        {
            var posts = await _feedBusiness.RetriveAsync(url);

            foreach (var post in posts)
            {
                await _textBusiness.CreateAsync(new CreateText(post.MainContent, post.Title));
            }

            return posts;
        }
    }
}