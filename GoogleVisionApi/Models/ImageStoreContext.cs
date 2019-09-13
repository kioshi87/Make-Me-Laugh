using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleVisionApi.Models
{
    public class ImageStoreContext : DbContext
    {
        public ImageStoreContext(DbContextOptions<ImageStoreContext> options) : base(options)
        {

        }
        public DbSet<ImageStore> ImageStore { get; set; }

        public DbSet<PlayerModel> PlayerModel { get; set; }

    }
}   
    
    

