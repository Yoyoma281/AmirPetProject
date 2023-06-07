using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AmirPetProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmirPetProject.Data;
using Tests;

namespace AmirPetProjectTests
{
    [TestClass]
    public class FakeDataBase
    {
        public DB? DbContext { get; private set; }

        [TestInitialize]
        public void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<DB>()
                 .UseInMemoryDatabase("F_DataBase")
                 .Options;
            
            DbContext = new DB(options);

        }
        
    }
}
