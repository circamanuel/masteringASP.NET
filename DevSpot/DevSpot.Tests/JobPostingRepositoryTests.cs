using DevSpot.Data;
using DevSpot.Models;
using DevSpot.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevSpot.Tests
{
    public class JobPostingRepositoryTests
    {
        private readonly DbContextOptions<ApplicationDbContext> _options;

        public JobPostingRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("JobPostingDb")
                .Options;
        }

        private ApplicationDbContext CreateDbContext() => new ApplicationDbContext(_options);

        [Fact]
        public async Task AddAsync_shouldAddJobPosting()
        {
            // db context
            var db = CreateDbContext();

            // job posting repository
            var repository = new JobPostingRepository(db);

            // job posting
            var jobPosting = new JobPosting
            {
                Title = "Test Title",
                Description = "Text Description",
                PostedDate = DateTime.Now,
                Company = "Test Company",
                Location = "Test Location",
                UserId = "TestUserId"
            };

            // excecute
            await repository.AddAsync(jobPosting);

            // result
            var result = db.JobPostings.SingleOrDefault(x => x.Title == "Test Title");

            // assert
            Assert.NotNull(result);
            Assert.Equal("Test Title", result.Title);
        }
    }
}
