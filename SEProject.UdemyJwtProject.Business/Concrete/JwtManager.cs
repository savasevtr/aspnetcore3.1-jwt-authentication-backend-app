﻿using Microsoft.IdentityModel.Tokens;
using SEProject.UdemyJwtProject.Business.Interfaces;
using SEProject.UdemyJwtProject.Business.StringInfos;
using SEProject.UdemyJwtProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SEProject.UdemyJwtProject.Business.Concrete
{
    public class JwtManager : IJwtService
    {
        public string GenerateJwtToken(AppUser appUser, List<AppRole> appRoles)
        {
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtInfo.SecurityKey));

            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: JwtInfo.Issuer,
                audience: JwtInfo.Audience,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(JwtInfo.TokenExpiration),
                signingCredentials: signingCredentials,
                claims: GetClaims(appUser, appRoles)
                );

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            return jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);
        }

        private List<Claim> GetClaims(AppUser appUser, List<AppRole> appRoles)
        {
            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name, appUser.UserName));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, appUser.Id.ToString()));

            if (appRoles.Count > 0)
            {
                foreach (var appRole in appRoles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, appRole.Name));
                }
            }

            return claims;
        }
    }
}