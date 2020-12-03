using SEProject.UdemyJwtProject.Entities.Interfaces;

namespace SEProject.UdemyJwtProject.Entities.Token
{
    public class JwtAccessToken : IToken
    {
        public string Token { get; set; }
    }
}