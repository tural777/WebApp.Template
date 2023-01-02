using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using WebApp.Template.Models;

namespace WebApp.Template.UserCards;


public class UserCardTagHelper : TagHelper
{
    public AppUser AppUser { get; set; }

    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserCardTagHelper(IHttpContextAccessor httpContextAccessor)
        => _httpContextAccessor = httpContextAccessor;


    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        UserCardTemplate userCardTemplate =
            _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated
            ? new PrimeUserCardTemplate()
            : new DefaultUserCardTemplate();


        userCardTemplate.SetUser(AppUser);

        output.Content.SetHtmlContent(userCardTemplate.Build());
    }
}