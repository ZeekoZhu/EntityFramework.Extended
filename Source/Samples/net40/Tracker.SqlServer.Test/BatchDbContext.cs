﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using EntityFramework.Extensions;
using Xunit;
using Tracker.SqlServer.CodeFirst;
using Tracker.SqlServer.CodeFirst.Entities;

namespace Tracker.SqlServer.Test
{
    
    public class BatchDbContext
    {
        [Fact]
        public void Delete()
        {
            var db = new TrackerContext();
            string emailDomain = "@test.com";
            int count = db.Users
                .Where(u => u.EmailAddress.EndsWith(emailDomain))
                .Delete();
        }
        [Fact]
        public void DeleteWhere()
        {
            var db = new TrackerContext();
            string emailDomain = "@test.com";

            //var user = db.Users.Select(u => new User { FirstName = u.FirstName, LastName = u.LastName });

            int count = db.Users
                .Where(u => u.EmailAddress.EndsWith(emailDomain))
                .Delete();
        }

        [Fact]
        public void Update()
        {
            var db = new TrackerContext();
            string emailDomain = "@test.com";
            int count = db.Users
                .Where(u => u.EmailAddress.EndsWith(emailDomain))
                .Update(u => new User { IsApproved = false, LastActivityDate = DateTime.Now });
        }

        [Fact]
        public void UpdateAppend()
        {
            var db = new TrackerContext();

            string emailDomain = "@test.com";
            string newComment = " New Comment";

            int count = db.Users
                .Where(u => u.EmailAddress.EndsWith(emailDomain))
                .Update(u => new User { LastName = u.LastName + newComment });
        }

        [Fact]
        public void UpdateAppendAndNull()
        {
            var db = new TrackerContext();

            string emailDomain = "@test.com";
            string newComment = " New Comment";

            int count = db.Users
                .Where(u => u.EmailAddress.EndsWith(emailDomain))
                .Update(u => new User
                {
                    FirstName = "Test",
                    LastName = u.LastName + newComment,
                    Comment = null
                });
        }

        [Fact]
        public void UpdateJoin()
        {
            var db = new TrackerContext();
            string emailDomain = "@test.com";
            string space = " ";

            int count = db.Users
                .Where(u => u.EmailAddress.EndsWith(emailDomain))
                .Update(u => new User { LastName = u.FirstName + space + u.LastName });
        }

        [Fact]
        public void UpdateCopy()
        {
            var db = new TrackerContext();
            string emailDomain = "@test.com";

            int count = db.Users
                .Where(u => u.EmailAddress.EndsWith(emailDomain))
                .Update(u => new User { Comment = u.LastName });
        }

    }

    public class TempUser
    {
        public string Name { get; set; }
    }
}
