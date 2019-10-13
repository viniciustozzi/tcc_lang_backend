using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TccLangBackend.Api.Controllers.Requests;
using TccLangBackend.Core.Text;
using TccLangBackend.Framework.Feed;

namespace TccLangBackend.Api.Controllers
{
    [Route("api/texts")]
    [ApiController]
    public class TextController : UtilControllerBase
    {
        private readonly FeedRepository _feedRepository;
        private readonly TextBusiness _textBusiness;

        public TextController(TextBusiness textBusiness, FeedRepository feedRepository)
        {
            _textBusiness = textBusiness;
            _feedRepository = feedRepository;
        }

        [HttpGet]
        public IEnumerable<SummaryText> GetTexts()
        {
            return _textBusiness.GetFeed();
        }

        [HttpPost]
        public Task SaveText([FromBody] CreateTextRequest createTextRequest)
        {
            return _textBusiness.CreateAsync(new CreateText(createTextRequest.Words, createTextRequest.Title));
        }

        [HttpGet("{textId}")]
        public Task<DetailedText> GetText(int textId)
        {
            return _textBusiness.GetAsync(UserId, textId);
        }

        [HttpGet("bookmarks")]
        public IEnumerable<SummaryText> GetBookmarks()
        {
            return _textBusiness.GetBookmarks(UserId);
        }

        [HttpPost("bookmarks")]
        public Task CreateBookmark([FromBody] CreateBookmarkRequest createBookmarkRequest)
        {
            return _textBusiness.CreateBookmark(new CreateBookmark(UserId, createBookmarkRequest.TextId));
        }

        [HttpPost("feed")]
        [AllowAnonymous]
        public async Task<IEnumerable<Post>> Feed([FromQuery] string url)
        {
            var posts = await _feedRepository.RetriveAsync(url);

            foreach (var post in posts) await _textBusiness.CreateAsync(new CreateText(post.MainContent, post.Title));

            return posts;
        }
    }
}