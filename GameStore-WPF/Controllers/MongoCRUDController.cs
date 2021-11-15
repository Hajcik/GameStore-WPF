using GameStore_WPF.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore_WPF.Controllers
{
    public class MongoCRUDController
    {
        MongoContext _dbContext;

        public MongoCRUDController()
        {
            _dbContext = new MongoContext();
        }

        
    }
}
