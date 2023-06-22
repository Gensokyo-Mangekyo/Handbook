using Handbook;
using Handbook.Models;
using Handbook.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace TestProject1
{
    public class Tests
    {
        ApplicationContext Database;

        [SetUp]
        public void Setup()
        {
            Database = new ApplicationContext();
        }

        [Test]
        public void Test1()
        {
            Assert.NotNull(Database.Catalogs.Where(x => x.Name == "Формулы").FirstOrDefault());
            Assert.NotNull(Database.Catalogs.SelectMany(x => x.chapters).SelectMany(x => x.Articles).Where(x => x.Title == "Тайтл")?.FirstOrDefault()?.ArticleId);
        }
    }
}