using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace DrugManagementAPI
{
    public class JWTMiddleware
    {
        private readonly RequestDelegate _next;
        public JWTMiddleware(RequestDelegate requestDelegate)
        {
            _next = requestDelegate;
        }
        public async Task InvokeAsync(HttpContext context, ClaimsPrincipal claimsPrincipal)
        {
            if(context.Request.Path =="/api/login" && context.Request.Method == "POST") 
            {
                await _next(context);
                return;
            }
            var authHeader = context.Request.Headers.Authorization;
            if(authHeader.Count()>0 && authHeader.FirstOrDefault().StartsWith("Bearer "))
            {
                var token = authHeader.FirstOrDefault().Substring("Bearer ".Length);
                var tokenHandler = new JwtSecurityTokenHandler();
                var key =Encoding.ASCII.GetBytes("!@#$%^&*()!@#$%^&*()");
                try
                {
                    var claims = tokenHandler.ValidateToken(token, new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience= false,
                        ClockSkew = TimeSpan.Zero
                    },out var validatedToken);
                    context.User = claimsPrincipal;
                }
                catch 
                {
                    context.Response.StatusCode = 401;
                    return;
                }
                _next(context);
            }
        }
    }
}
