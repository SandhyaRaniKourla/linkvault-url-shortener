using System;
using System.Collections.Generic;
using System.Text;

namespace LinkVault.Domain.Entities
{
    public  class UrlClick
    {
        public Guid Id { get; private set; }
        public Guid ShortUrlId { get; private set; }
        public DateTime ClickedAt { get; private set; }
        public string? UserAgent { get; private set; }
        public string? Referrer { get; private set; }

        private UrlClick() { }
        public UrlClick(Guid shortUrlId, string? userAgent = null, string? referrer = null)
        {
            if (shortUrlId == Guid.Empty)
                throw new ArgumentException("Short URL ID cannot be empty.", nameof(shortUrlId));
            Id = Guid.NewGuid();
            ShortUrlId = shortUrlId;
            ClickedAt = DateTime.UtcNow;
            UserAgent = userAgent;
            Referrer = referrer;
        }
    }
}
