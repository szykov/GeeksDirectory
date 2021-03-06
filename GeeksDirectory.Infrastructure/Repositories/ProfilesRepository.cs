﻿using GeeksDirectory.Domain.Entities;
using GeeksDirectory.Domain.Interfaces;
using GeeksDirectory.Domain.Classes;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;

namespace GeeksDirectory.Infrastructure.Repositories
{
    public class ProfilesRepository : IProfilesRepository
    {
        private readonly ApplicationDbContext context;

        public ProfilesRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<GeekProfile> GetProfiles(QueryOptions queryOptions)
        {
            if (queryOptions is null)
                throw new ArgumentNullException(paramName: nameof(queryOptions));

            var result = this.context.Profiles
                .Include(prf => prf.Skills)
                .Include(prf => prf.User)
                .AsQueryable();

            if (queryOptions.IsSortable())
                result = this.Sort(result, queryOptions.OrderDirection, queryOptions.OrderBy!);

            return result.Skip(queryOptions.Offset).Take(queryOptions.Limit);
        }

        public GeekProfile? GetProfileById(long profileId)
        {
            if (profileId == 0)
                throw new ArgumentException(message: $"Argument {nameof(profileId)} is invalid.");

            return this.context.Profiles
                .Include(prf => prf.Skills)
                .Include(prf => prf.User)
                .Where(prf => prf.Id == profileId)
                .SingleOrDefault();
        }

        public GeekProfile? GetProfileByUserName(string userName)
        {
            if (String.IsNullOrEmpty(userName))
                throw new ArgumentException(message: $"Argument {nameof(userName)} is invalid.");

            return this.context.Profiles
                .Include(prf => prf.Skills)
                .Include(prf => prf.User)
                .Where(prf => prf.User.UserName == userName)
                .SingleOrDefault(); ;
        }

        public bool UserExists(string email)
        {
            if (String.IsNullOrEmpty(email))
                throw new ArgumentException(message: $"Argument {nameof(email)} is invalid.");

            var normalizedEmail = email.Normalize().ToUpperInvariant();

            return this.context.Profiles
                .Include(prf => prf.User)
                .Where(prf => prf.User.NormalizedEmail == normalizedEmail)
                .Any();
        }

        public IEnumerable<GeekProfile> Search(QueryOptions queryOptions, out long total)
        {
            if (queryOptions is null)
                throw new ArgumentNullException(paramName: nameof(queryOptions));

            if (String.IsNullOrEmpty(queryOptions.Query))
                throw new ArgumentNullException(paramName: nameof(queryOptions.Query));


            var result = this.context.Profiles
                .Include(prf => prf.Skills)
                .Include(prf => prf.User)
                .Where(prf => EF.Functions.Like(prf.Name, queryOptions.Query) ||
                    EF.Functions.Like(prf.Surname, queryOptions.Query) ||
                    EF.Functions.Like(prf.MiddleName, queryOptions.Query) ||
                    EF.Functions.Like(prf.City, queryOptions.Query) ||
                    prf.Skills.Any(skl => EF.Functions.Like(skl.Name, queryOptions.Query)));

            total = result.Count();

            if (queryOptions.IsSortable())
                result = this.Sort(result, queryOptions.OrderDirection, queryOptions.OrderBy!);

            return result.Skip(queryOptions.Offset).Take(queryOptions.Limit);
        }

        public void Update(GeekProfile profile)
        {
            if (profile is null)
                throw new ArgumentNullException(paramName: nameof(profile));

            this.context.Profiles.Update(profile);
            context.SaveChanges();
        }

        public void Add(GeekProfile profile)
        {
            if (profile is null)
                throw new ArgumentNullException(paramName: nameof(profile));

            this.context.Profiles.Add(profile);
            context.SaveChanges();
        }

        public long Total()
        {
            return this.context.Profiles.LongCount();
        }

        private IQueryable<GeekProfile> Sort(IQueryable<GeekProfile> profiles, OrderDirection orderDirection, string OrderBy)
        {
            return orderDirection == OrderDirection.Asc ? 
                profiles.OrderBy(p => EF.Property<object>(p, OrderBy)) : 
                profiles.OrderByDescending(p => EF.Property<object>(p, OrderBy));
        }
    }
}
