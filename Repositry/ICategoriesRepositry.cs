﻿using BookDownloader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookDownloader.Repositry
{
    public interface ICategoriesRepositry: IRepositry<Category,int>
    {
    }
}