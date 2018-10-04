namespace WebApplication1
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using WebApplication1.Models;

    public class Model : DbContext
    {       
        public Model()
            : base("Model")
        {
        }        

        public virtual DbSet<Product> Products { get; set; }
    }
    
}