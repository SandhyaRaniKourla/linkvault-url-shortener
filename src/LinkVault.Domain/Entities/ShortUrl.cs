using System;
using System.Collections.Generic;
using System.Text;

namespace LinkVault.Domain.Entities
{
    public class ShortUrl
    {
        public Guid Id { get; private set; }
        public string OriginalUrl { get; private set; } = string.Empty;

        public string ShortCode { get; private set; } = string.Empty;
        public DateTime? CreatedAt { get; private set; }
        public DateTime? ExpiresAt { get; private set; }
        public bool IsActive { get; private set; }

        public ICollection<UrlClick> UrlClicks { get; private set; } = new List<UrlClick>();

        private ShortUrl() { }
        public ShortUrl(string originalUrl, string shortCode, DateTime? expiresAt = null)
        {
            if (string.IsNullOrWhiteSpace(originalUrl))
                throw new ArgumentException("Original URL cannot be null or empty.", nameof(originalUrl));
            if (string.IsNullOrWhiteSpace(shortCode))
                throw new ArgumentException("Short code cannot be null or empty.", nameof(shortCode));
            if (expiresAt.HasValue && expiresAt.Value <= DateTime.UtcNow)
                throw new ArgumentException("Expiration date must be in the future.", nameof(expiresAt));

            Id = Guid.NewGuid();
            OriginalUrl = originalUrl;
            ShortCode = shortCode;
            CreatedAt = DateTime.UtcNow;
            ExpiresAt = expiresAt;
            IsActive = true;
        }
        public bool IsExpired()
        {
            return ExpiresAt.HasValue && ExpiresAt.Value <= DateTime.UtcNow;
        }
        public bool CanRedirect()
        {
            return IsActive && !IsExpired();
        }
        public void Deactivate()
        {
            IsActive = false;
        }
    }
}
