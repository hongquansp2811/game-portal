namespace GamePortal.Core.Entities;

public class SiteSettings : BaseEntity
{
    public string SiteName { get; set; } = "GamePortal";
    public string? SiteDescription { get; set; }
    public string? LogoUrl { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public string? FacebookUrl { get; set; }
    public string? TwitterUrl { get; set; }
    public string? InstagramUrl { get; set; }
    public string? YoutubeUrl { get; set; }
    public string? PrivacyPolicyUrl { get; set; }
    public string? DisclaimerUrl { get; set; }
    public string? TermsOfServiceUrl { get; set; }
    public string? CopyrightText { get; set; }
    public string? FooterDescription { get; set; }
}

