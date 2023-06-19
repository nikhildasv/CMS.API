﻿using Cms.Data.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Data.Repository.Repositories
{
    public interface ICmsRepository
    {
        IEnumerable<Course> GetAllCourses();
    }
}
