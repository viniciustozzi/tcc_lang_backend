using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TccLangBackend.Api.Controllers.Requests;
using TccLangBackend.Core.Feed;
using TccLangBackend.Core.Text;
using TccLangBackend.Framework.Content;

namespace TccLangBackend.Api.Controllers
{
    [Route("api/texts")]
    [ApiController]
    public class TextController : UtilControllerBase
    {
        private readonly IContentRepository _contentRepository;
        private readonly FeedBusiness _feedBusiness;
        private readonly TextBusiness _textBusiness;

        public TextController(TextBusiness textBusiness, IContentRepository contentRepository,
            FeedBusiness feedBusiness)
        {
            _textBusiness = textBusiness;
            _contentRepository = contentRepository;
            _feedBusiness = feedBusiness;
        }

        [HttpGet]
        public IEnumerable<SummaryText> GetTexts([FromQuery] string lang = "de")
        {
            return _textBusiness.GetFeed(lang);
        }

        [HttpPost]
        public Task SaveText([FromBody] CreateTextRequest createTextRequest)
        {
            return _textBusiness.CreateAsync(new CreateText(createTextRequest.Words, createTextRequest.Title,
                createTextRequest.Language));
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
        public Task CreateBookmark([FromQuery] CreateBookmarkRequest createBookmarkRequest)
        {
            return _textBusiness.CreateBookmarkAsync(new CreateBookmark(UserId, createBookmarkRequest.TextId));
        }

        [HttpPost("feed")]
        [AllowAnonymous]
        public Task Feed()
        {
            return _feedBusiness.FillDatabaseWithBigData();
        }
    }
}