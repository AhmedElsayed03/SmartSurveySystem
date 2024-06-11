using Microsoft.EntityFrameworkCore;
using Survey.Application.Abstractions.Repositories;
using Survey.Infrastructure.Data.Context;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Survey.Infrastructure.Data.Repositories
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly SurveyDbContext _dbContext;
        public GenericRepo(SurveyDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        //GetAll
        public virtual async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>()
                .ToListAsync();
        }

        //GetById
        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>()
                .FindAsync(id);
        }

        //Add
        public virtual async Task AddAsync(T entity)
        {
            await _dbContext.Set<T>()
                .AddAsync(entity);
        }

        //Update
        public virtual void UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        //Delete
        public virtual void DeleteAsync(T entity)
        {
            _dbContext.Set<T>()
                .Remove(entity);
        }


        //Get User Id from token
        public async Task<int> GetUserFormTokenAsync(string tokenFromHeader /*Request.Headers.Authorization*/)
        {
            // Fetching Token From Header
            string? token = tokenFromHeader;

            // Cut off the Prefix "Bearer"
            if (!string.IsNullOrEmpty(token) && token.StartsWith("Bearer "))
            {
                token = token.Substring("Bearer ".Length).Trim();
            }

            return await Task.Run(() =>
            {
                try
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var jwtToken = tokenHandler.ReadJwtToken(token);
                    IEnumerable<Claim> claims = jwtToken.Claims;

                    // Use LINQ to find the user ID claim
                    var userIdClaim = claims.FirstOrDefault(claim => claim.Type == ClaimTypes.NameIdentifier);

                    if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
                    {
                        return userId;
                    }
                    else
                    {
                        // Handle the case where the userId claim is not found or cannot be parsed to an int
                        return -1; // Or throw an exception, or return a default value
                    }
                }
                catch (Exception ex)
                {
                    // Handle the exception (log it, rethrow it, return a default value, etc.)
                    return -1; // Or throw an exception, or return a default value
                }
            });

        }
    }
}
